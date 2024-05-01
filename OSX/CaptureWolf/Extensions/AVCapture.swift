//
//  AVCapture.swift
//  CaptureWolf
//
//  Created by Ramon Klanke on 18/03/2024.
//

import Foundation
import AVFoundation
import AppKit

extension CaptureModel: AVCapturePhotoCaptureDelegate {
    func photoOutput(_ output: AVCapturePhotoOutput, didFinishProcessingPhoto photo: AVCapturePhoto, error: Error?) {
        guard let data = photo.fileDataRepresentation(),
              let image = NSImage(data: data) else {
            return
        }
        capturedImage = image
        //let name = randomString()
        let yyy = image.withVignetteRing()
        let xxx = yyy.withWatermark(text: "Thanks for keeping me sharp!", textColor: .white)
        saveImageToDesktop(xxx)
    }
}
