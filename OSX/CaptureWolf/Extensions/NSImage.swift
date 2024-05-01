//
//  NSImage.swift
//  CaptureWolf
//
//  Created by Ramon Klanke on 11/04/2024.
//

import Foundation
import AppKit

extension NSImage {
    func withWatermark(text: String, textColor: NSColor = .white, font: NSFont = NSFont.systemFont(ofSize: 32)) -> NSImage {
        
        let imageWidth = CGFloat( self.size.width)
        let imageHeight = CGFloat( self.size.height)
   
        let imageSize = CGSize(width: imageWidth, height: imageHeight)
        let imageRect = CGRect(origin: .zero, size: imageSize)
        
        let outputImage = NSImage(size: imageSize)
        
        outputImage.lockFocus()
        
        // Draw original image
        self.draw(in: imageRect)
        
        let paragraph = NSMutableParagraphStyle()
        paragraph.alignment = .center
        
        // Prepare text attributes
        let attributes: [NSAttributedString.Key: Any] = [
            .font: font,
            .foregroundColor: textColor,
            .paragraphStyle: paragraph
            
        ]
        
        // Calculate the size of the text
        let textSize = text.size(withAttributes: attributes)
        
        // Calculate the position to draw the text (bottom right corner with padding)
        let textOrigin = NSPoint(x: (imageWidth / 2) - (textSize.width / 2), y: 10)
        
        // Draw the text
        text.draw(at: textOrigin, withAttributes: attributes)
        
        let watermarkImg =  NSImage(named: "Logo")!
        let watermarkSize = NSSize(width: 100, height: 100) // Adjust the size as needed
        let watermarkRect = NSRect(x: imageWidth - watermarkSize.width - 10, y: imageHeight - watermarkSize.height - 10, width: watermarkSize.width, height: watermarkSize.height)

        watermarkImg.draw(in: watermarkRect, from: .zero, operation: .sourceOver, fraction: 1.0)
               
        outputImage.unlockFocus()
        
        return outputImage
    }
    
    func withVignetteRing() -> NSImage {
  
        let imageWidth = CGFloat( self.size.width)
        let imageHeight = CGFloat( self.size.height)
        
        let imageSize = CGSize(width: imageWidth, height: imageHeight)
        let imageRect = CGRect(origin: .zero, size: imageSize)
        
        let outputImage = NSImage(size: imageSize)
        outputImage.lockFocus()
        
        // Draw original image
        self.draw(in: imageRect)
        
        let startRadius = sqrt(pow(imageSize.width/6, 2) + pow(imageSize.height/6, 2))
        let endRadius = sqrt(pow(imageSize.width/2, 2) + pow(imageSize.height/2, 2))
        let center = CGPoint(x: imageSize.width / 2, y: imageSize.height / 2)
        let gradient = CGGradient(colorsSpace: CGColorSpaceCreateDeviceRGB(), colors: [NSColor.clear.cgColor, NSColor.black.cgColor] as CFArray, locations: nil)

        let context = NSGraphicsContext.current?.cgContext
        
        context?.saveGState()
        context?.clip(to: imageRect)
        
        context?.drawRadialGradient(gradient!, startCenter: center, startRadius: startRadius, endCenter: center, endRadius: endRadius, options: CGGradientDrawingOptions.drawsBeforeStartLocation)
        
        context?.restoreGState()
        
        outputImage.unlockFocus()
        
        return outputImage
    }
}
