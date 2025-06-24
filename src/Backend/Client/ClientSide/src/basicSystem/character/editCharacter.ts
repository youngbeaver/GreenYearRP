class EditCharacter {
    constructor() {
        mp.events.add({
            "client:localEditCharacter": this.localEditCharacter.bind(this)
        })
    }

    private localEditCharacter = (data: any[]): void => {

    }
}