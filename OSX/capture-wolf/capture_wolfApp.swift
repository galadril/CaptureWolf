//
//  capture_wolfApp.swift
//  capture-wolf
//
//  Created by Ramon Klanke on 19/04/2024.
//

import SwiftUI

@main
struct capture_wolfApp: App {
    var body: some Scene {
        WindowGroup {
            CaptureView()
                .environmentObject(SleepPreventionManager())
        }
    }
}
