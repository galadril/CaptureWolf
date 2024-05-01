//
//  CaptureWolfApp.swift
//  CaptureWolf
//
//  Created by Ramon Klanke on 19/04/2024.
//

import SwiftUI

@main
struct CaptureWolfApp: App {
    var body: some Scene {
        WindowGroup {
            CaptureView()
                .environmentObject(SleepPreventionManager())
        }
    }
}
