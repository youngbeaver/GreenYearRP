import "./admins";
class Index {
    constructor() {
        mp.events.add("playerReady", this.playerReady.bind(this));
    }
    playerReady() {
        mp.gui.chat.push("ui start");
    }
}
