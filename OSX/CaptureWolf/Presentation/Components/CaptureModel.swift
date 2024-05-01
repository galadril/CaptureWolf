//
//  CaptureModel.swift
//  CaptureWolf
//
//  Created by Ramon Klanke on 18/03/2024.
//

import SwiftUI
import AVFoundation

class CaptureModel: NSObject, ObservableObject {
    let captureSession = AVCaptureSession()
    var photoOutput: AVCapturePhotoOutput?
    var currentCamera: AVCaptureDevice?
    @Published var capturedImage:NSImage?
    
    override init() {
        super.init()
        setupCaptureSession()
        setupDevices()
        setupInputOutput()
    }
    
    func setupCaptureSession() {
        captureSession.sessionPreset = AVCaptureSession.Preset.photo
    }
    
    func setupDevices() {
        guard let device = AVCaptureDevice.default(for: .video) else {
            print("No camera found")
            return
        }
        currentCamera = device
    }
    
    func setupInputOutput() {
        
        do {
            //you only get here if there is a camera ( ! ok )
            let captureDeviceInput = try AVCaptureDeviceInput(device: currentCamera!)
            captureSession.addInput(captureDeviceInput)
            
            
            photoOutput = AVCapturePhotoOutput()
            
            
            captureSession.addOutput(photoOutput!)
            captureSession.commitConfiguration()
            
        } catch {
            print("Error creating AVCaptureDeviceInput:", error)
        }
        
    }
    
    func startRunningCaptureSession() {
        //let settings = AVCapturePhotoSettings()
        let settings = AVCapturePhotoSettings(format: [AVVideoCodecKey: AVVideoCodecType.jpeg])
        
        captureSession.startRunning()
        
        DispatchQueue.main.asyncAfter(deadline: .now() + .seconds(1), execute: {
            self.photoOutput?.capturePhoto(with: settings, delegate: self)
        })
    }
    
    func stopRunningCaptureSession() {
        captureSession.stopRunning()
    }
    
    func saveImageToDesktop(_ image: NSImage) {
        // Convert NSImage to Data
        guard let imageData = image.tiffRepresentation,
              let bitmap = NSBitmapImageRep(data: imageData),
              let data = bitmap.representation(using: .jpeg, properties: [:]) else {
            print("Failed to convert image to JPEG data")
            return
        }
        
        // Save Data to file
        let desktopURL = FileManager.default.urls(for: .downloadsDirectory, in: .userDomainMask).first!
        let fileURL = desktopURL.appendingPathComponent("captured_image.jpg")
        
        do {
            try data.write(to: fileURL)
            print("Image saved to \(fileURL)")
        } catch {
            print("Failed to save image:", error)
        }
    }
}
