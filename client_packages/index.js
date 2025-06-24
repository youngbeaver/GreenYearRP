// src/admins/fly.ts
var controlsIds = {
  F6: 117,
  W: 32,
  S: 33,
  A: 34,
  D: 35,
  Space: 321,
  LCtrl: 326,
  LMB: 24,
  RMB: 25
};
var player = mp.players.local;
var FlyMode = class {
  enabled = false;
  forward = 2;
  height = 2;
  l = 2;
  constructor() {
    mp.keys.bind(controlsIds.F6, false, this.toggle.bind(this));
    mp.events.add({
      render: this.onRender.bind(this)
    });
  }
  toggle() {
    this.enabled = !this.enabled;
    player.freezePosition(this.enabled);
    if (!this.enabled) {
      const { position } = player;
      const groundDist = mp.game.gameplay.getGroundZFor3dCoord(
        position.x,
        position.y,
        position.z,
        true,
        false
      );
      this.setCoords(position.x, position.y, groundDist);
    }
    mp.game.graphics.notify(this.enabled ? "Fly: ~g~Enabled" : "Fly: ~r~Disabled");
  }
  onRender() {
    if (!this.enabled) return;
    const { controls } = mp.game;
    const { position } = player;
    const direction = mp.cameras.gameplay.getDirection();
    let speed = 0.2;
    let updated = false;
    mp.game.controls.enableControlAction(2, 24, true);
    if (controls.isControlPressed(0, controlsIds.LMB)) speed = 1;
    else if (controls.isControlPressed(0, controlsIds.RMB)) speed = 0.02;
    if (controls.isControlPressed(0, controlsIds.W)) {
      position.x += direction.x * this.forward * speed;
      position.y += direction.y * this.forward * speed;
      position.z += direction.z * this.forward * speed;
      updated = true;
    } else if (controls.isControlPressed(0, controlsIds.S)) {
      position.x -= direction.x * this.forward * speed;
      position.y -= direction.y * this.forward * speed;
      position.z -= direction.z * this.forward * speed;
      updated = true;
    } else this.forward = 2;
    if (controls.isControlPressed(0, controlsIds.A)) {
      if (this.l < 8) this.l *= 1.025;
      position.x += -direction.y * this.l * speed;
      position.y += direction.x * this.l * speed;
      updated = true;
    } else if (controls.isControlPressed(0, controlsIds.D)) {
      if (this.l < 8) this.l *= 1.05;
      position.x -= -direction.y * this.l * speed;
      position.y -= direction.x * this.l * speed;
      updated = true;
    } else this.l = 2;
    if (controls.isControlPressed(0, controlsIds.Space)) {
      if (this.height < 8) this.height *= 1.025;
      position.z += this.height * speed;
      updated = true;
    } else if (controls.isControlPressed(0, controlsIds.LCtrl)) {
      if (this.height < 8) this.height *= 1.05;
      position.z -= this.height * speed;
      updated = true;
    } else this.height = 2;
    if (updated) this.setCoords(position.x, position.y, position.z);
  }
  setCoords(x, y, z) {
    player.setCoordsNoOffset(x, y, z, false, false, false);
  }
};

// src/admins/index.ts
new FlyMode();

// src/utils/events.ts
var Events = class {
  constructor() {
    mp.events.add("utils:SendEventToServer", this.callServerFromBrowser.bind(this));
  }
  callServerFromBrowser(eventName, ...args) {
    mp.events.callRemote(eventName, ...args);
  }
};

// src/utils/index.ts
new Events();

// src/index.ts
var Index = class {
  browser = null;
  constructor() {
    mp.events.add("playerReady", this.playerReady.bind(this));
  }
  playerReady() {
    this.browser = mp.browsers.new("package://cef/index.html");
    this.browser.active = true;
  }
};
new Index();
