//
//  SleepPreventionManager.swift
//  CaptureWolf
//
//  Created by Ramon Klanke on 10/04/2024.
//

import SwiftUI
import Foundation
import Cocoa

class SleepPreventionManager: ObservableObject {
    private var timer: Timer?

    func startPreventingLock() {
        // Create a timer that fires periodically to simulate user activity
        timer = Timer.scheduledTimer(withTimeInterval: 60, repeats: true) { _ in
            // Simulate a key press event (Escape key)
            let src = CGEventSource(stateID: .hidSystemState)
            let keyDown = CGEvent(keyboardEventSource: src, virtualKey: 0x38, keyDown: true) // Mute
            let keyUp = CGEvent(keyboardEventSource: src, virtualKey: 0x38, keyDown: false) // Mute
            keyDown?.post(tap: .cghidEventTap)
            keyUp?.post(tap: .cghidEventTap)
        }
        timer?.tolerance = 10
        timer?.fire()
    }

    func stopPreventingLock() {
        timer?.invalidate()
        timer = nil
    }
}
