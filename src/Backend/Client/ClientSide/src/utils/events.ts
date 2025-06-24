export default class Events {
    constructor() {
        mp.events.add("utils:SendEventToServer", this.callServerFromBrowser.bind(this))
    }

    private callServerFromBrowser(eventName: string, ...args: any[]): void {
        mp.events.callRemote(eventName, ...args);
    }
}