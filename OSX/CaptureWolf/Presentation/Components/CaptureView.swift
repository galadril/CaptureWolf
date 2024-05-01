//
//  CaptureView.swift
//  CaptureWolf
//
//  Created by Ramon Klanke on 18/03/2024.
//

import SwiftUI
import Security
import Foundation
import ScriptingBridge

struct CaptureView: View {
    @EnvironmentObject var sleepManager: SleepPreventionManager
    @StateObject var model = CaptureModel()
    @State private var isActive = false
    @State private var isActivity = false
    @State private var hideWindows = true
    
    var body: some View {
        VStack {
            if(self.isActivity) {
                model.capturedImage.map { capturedImage in
                    Button(action: {
                        openFolder()
                    }) {
                        Image(nsImage: capturedImage)
                            .resizable()
                            .aspectRatio(contentMode: .fit)
                            .frame(height: 200)
                            .padding()
                    }
                    .buttonStyle(PlainButtonStyle())
                    .onHover { inside in
                        if inside { NSCursor.openHand.push() }
                            else {  NSCursor.pop() }
                    }
                }
                .cornerRadius(10)
            }else {
                Image("Logo")
                    .resizable()
                    .aspectRatio(contentMode: .fit)
                    .frame(height: 200)
                    .padding()
            }
            
            Toggle("Minimize all windows", isOn: $hideWindows)
            
            Button(action: {
                if(self.hideWindows) {
                    minimizeAll()
                }else {
                    minimize()
                }
                
                DispatchQueue.main.asyncAfter(deadline: .now() + 2
                ) {
                    self.isActivity = false
                    self.isActive = true
                }
            }) {
                Text("Start luring")
                    .padding([.horizontal], 14)
                    .padding([.vertical], 14)
                    .font(.system(size: 16, weight: Font.Weight.medium))
                    .frame(alignment: .bottom)
                    .foregroundColor(Color("FontColor"))
                    .background(Color("CallToAction"))
                    .cornerRadius(10)
                    .shadow(radius: 5, y: 5)
                    .padding()
            }
            .buttonStyle(PlainButtonStyle())
           
            .onHover { inside in
                if inside { NSCursor.openHand.push() }
                    else {  NSCursor.pop() }
            }
            
            if(self.isActivity) {
                Text("We captured one!!!")
                    .padding(20)
            } else {
                Text("Sheeps stick together, start luring in the Wolves!")
                    .padding(20)
            }
        
        }
            .background(Color("BackgroundColor"))
            .foregroundColor(Color("FontColor"))
        
            .onAppear {
                // Prevent the system from going to sleep while the app is running
                sleepManager.startPreventingLock()
            }
            .onDisappear {
                // Allow the system to sleep when the app is no longer active
                sleepManager.stopPreventingLock()
            }

            .onReceive(NotificationCenter.default.publisher(for: NSApplication.didHideNotification)) { _ in
                //print("Application hidden")
            }
            .onReceive(NotificationCenter.default.publisher(for: NSApplication.willUpdateNotification)) { _ in
                //print("Application will update")
            }
           
            .onChange(of: self.isActive) {
                guard self.isActive else {return}
                
                DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                    NSEvent.addGlobalMonitorForEvents(matching: [.keyDown, .flagsChanged]) { event  in
                        if event.keyCode == 0x38 {
                            // triggerd for keeping mac alive!!!
                        }else {
                            self.isActivity = true
                        }
                        if event.type != .keyDown {
                            self.isActivity = true
                        }
                    }
                    NSEvent.addGlobalMonitorForEvents(matching: [.mouseMoved]) {event in
                        self.isActivity = true
                    }
                    
                    NSEvent.addLocalMonitorForEvents(matching: [.keyDown, .flagsChanged]) { event  in
                        if event.keyCode == 0x38 {
                            // triggerd for keeping mac alive!!!
                        }else {
                            self.isActivity = true
                        }
                        if event.type != .keyDown {
                            self.isActivity = true
                        }
                        return event
                    }
                    NSEvent.addLocalMonitorForEvents(matching: [.mouseMoved]) {event in
                        self.isActivity = true
                        return event
                    }
                }
            }
        
            .onChange(of: self.isActivity) {
                guard self.isActivity else {return}
                
                model.startRunningCaptureSession()
                
                DispatchQueue.main.asyncAfter(deadline: .now() + 0.5) {
                    minimize(value: false)
                }
                
                DispatchQueue.main.asyncAfter(deadline: .now() + 1) {
                    model.stopRunningCaptureSession()
                    lockScreen()
                }
            }
    }
}

#Preview {
    CaptureView()
        .environmentObject(SleepPreventionManager())
}
