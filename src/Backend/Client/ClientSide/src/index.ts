import "./admins";
import "./utils";

class Index {
    private browser: BrowserMp = null;

    constructor() {
        mp.events.add("playerReady", this.playerReady.bind(this));
    }

    private playerReady() {
        this.browser = mp.browsers.new('package://cef/index.html');
        this.browser.active = true;
    }
}

new Index();