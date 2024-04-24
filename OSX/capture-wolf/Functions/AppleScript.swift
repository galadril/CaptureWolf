//
//  AppleScript.swift
//  capture-wolf
//
//  Created by Ramon Klanke on 11/04/2024.
//

import Foundation
import AppKit

func minimize(value: Bool = true) {
    DispatchQueue.global(qos: .background).async {
        let lockScript = """
            tell application "System Events"
                tell process "capture-wolf"
                        set frontWindow to the first window
                        tell frontWindow
                            set value of attribute "AXMinimized" to \(value)
                        end tell
                    end tell
            end tell
        """

        if let scriptObject = NSAppleScript(source: lockScript) {
            var error: NSDictionary?
            scriptObject.executeAndReturnError(&error)
            if let error = error {
                print("Error locking screen: \(error)")
            }
        }
    }
}


func minimizeAll() {
    DispatchQueue.global(qos: .background).async {
        let lockScript = """
            tell application "System Events"
                if not (exists application process "System Events") then
                    return
                end if
                keystroke "hm" using {command down, option down}
            end tell
        """
        if let scriptObject = NSAppleScript(source: lockScript) {
            var error: NSDictionary?
            scriptObject.executeAndReturnError(&error)
            if let error = error {
                print("Error locking screen: \(error)")
            }
        }
    }
}

func lockScreen() {
    DispatchQueue.global(qos: .background).async {
        let lockScript = """
            tell application "System Events"
                if not (exists application process "System Events") then
                    return
                end if
                keystroke "q" using {command down, control down}
            end tell
        """
        if let scriptObject = NSAppleScript(source: lockScript) {
            var error: NSDictionary?
            scriptObject.executeAndReturnError(&error)
            if let error = error {
                print("Error locking screen: \(error)")
            }
        }
    }
}

func openFolder() {
   let workspace = NSWorkspace.shared
   let downloadsURL = FileManager.default.urls(for: .downloadsDirectory, in: .userDomainMask).first!
      
    let fileURL = downloadsURL.appendingPathComponent("captured_image.jpg")
    
    workspace.activateFileViewerSelecting([fileURL])
   }

func randomString() -> String {
    let strings = ["Code Sniffer", "Bug Hunter", "Loop Master", "Syntax Surfer", "Exception Exterminator",
                   "Recursion Wrangler", "Algorithm Whisperer", "Binary Boss", "Data Wrangler", "Git Guru",
                   "Java Juggler", "Python Tamer", "Ruby Rider", "SQL Slinger", "CSS Conqueror",
                   "HTML Hero", "JS Jester", "PHP Phantom", "Swift Swashbuckler", "Kotlin Knight",
                   "C# Sharpshooter", "Rust Ranger", "Go Gopher", "TypeScript Titan", "Shell Sheriff",
                   "Perl Pioneer", "Lua Luminary", "Rascal R", "Scala Scaler", "Groovy Guru",
                   "Haskell Hawk", "Erlang Eagle", "Clojure Conjurer", "Dart Daredevil", "F# Fencer",
                   "Cobol Cowboy", "Fortran Foreman", "Pascal Paladin", "Assembly Archer", "Matlab Magician",
                   "Objective-C Oracle", "CoffeeScript Captain", "Elixir Enchanter", "Vue Viking",
                   "React Ranger", "Angular Angel", "Django Juggernaut", "Flask Falcon", "Laravel Lancer",
                   "Spring Samurai", "Bit Baron", "Query Queen", "Debugging Diva", "Lambda Lord", "Framework Fencer",
                   "Cache Conqueror", "Protocol Paladin", "Network Ninja", "Database Druid", "Server Samurai",
                   "Byte Boss", "Pixel Prince", "Kernel King", "Thread Tsar", "Heap Hero",
                   "Stack Sultan", "Memory Monarch", "Function Pharaoh", "Class Czar", "Interface Imperator",
                   "Method Maestro", "Variable Viscount", "Array Archduke", "Pointer Pope", "Loop Lord",
                   "Boolean Baronet", "Exception Earl", "Recursion Raja", "Syntax Sheikh", "Algorithm Admiral",
                   "Binary Baron", "Commander CSS", "HTML Headman", "JavaScript Jedi", "Python Pharaoh",
                   "Ruby Ruler", "SQL Sultan", "TypeScript Tsar", "Vue Viscount", "React Regent",
                   "Angular Archduke", "Django Duke", "Flask Führer", "Laravel Lord", "Spring Sovereign"]
    
    guard let randomIndex = strings.indices.randomElement() else {
        return "No strings available"
    }
    
    return strings[randomIndex]
}
