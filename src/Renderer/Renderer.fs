module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Electron
open Node.Exports
open Fable.PowerPack

open Fable.Import.Browser

// open DevTools to see the message
// Menu -> View -> Toggle Developer Tools
Browser.console.log "Hi from the renderer.js" |> ignore

// Reference the element of the View used by the application
module Ref =

    let fontSize: HTMLSelectElement =
        Browser.document.getElementById("font-size") :?> HTMLSelectElement
    let register (id: int): HTMLElement =
        Browser.document.getElementById(sprintf "R%i" id)
    let explore: HTMLButtonElement =
        Browser.document.getElementById("explore") :?> HTMLButtonElement
    let save: HTMLButtonElement =
        Browser.document.getElementById("save") :?> HTMLButtonElement
    let run: HTMLButtonElement =
        Browser.document.getElementById("run") :?> HTMLButtonElement
    let flag (id: string): HTMLElement =
        Browser.document.getElementById(sprintf "flag_%s" id)
    let code: unit -> string = fun _ ->
        window?code?getValue() :?> string

// Update UI elements
module Update =

    let fontSize (size: int) =
        let options = createObj ["fontSize" ==> size]
        window?code?updateOptions options
    let register (id: int) (value: int) =
        let el = Ref.register id
        el.setAttribute("style", "background: #fbbc05")
        el.innerHTML <- sprintf "0x%X" value
    let flag (id: string) (value: bool) =
        let el = Ref.flag id
        match value with
            | false ->
                el.setAttribute("style", "background: #fcfcfc")
                el.innerHTML <- sprintf "%i" 0
            | true ->
                el.setAttribute("style", "background: #4285f4")
                el.innerHTML <- sprintf "%i" 1
    let code (text: string) =
        window?code?setValue(text)

let init () =
    Ref.fontSize.addEventListener_change(fun _ ->
        let size: int =
            // TODO: error-prone, hardcoded index
            // of word "Font Size: xx" to slice
            Ref.fontSize.value.[11..]
            |> int
        Browser.console.log "Font size updated" |> ignore
        Update.fontSize size
    )
    // TODO: Implement actions for the buttons
    Ref.explore.addEventListener_click(fun _ ->
        Browser.console.log "Code updated"
        Update.code("mov r7, #5")
    )
    Ref.save.addEventListener_click(fun _ ->
        Browser.window.alert "NotImplemented :|"
    )
    Ref.run.addEventListener_click(fun _ ->
        Browser.window.alert "NotImplemented :|"
    )
    // just for fun!
    (Ref.register 0).addEventListener_click(fun _ ->
        Browser.console.log "register R0 changed!" |> ignore
        Update.register 0 (System.Random().Next 1000)
    )
    (Ref.flag "N").addEventListener_click(fun _ ->
        Browser.console.log "flag N changed!" |> ignore
        Update.flag "N" true
    )

init()