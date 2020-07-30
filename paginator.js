const Jshaku = require('./jshaku');
const Discord = require('discord.js');

class Paginator extends Jshaku {
    constructor(prefix="```js\n", suffix="```") {
        this.pages = []
        this.autoPage = {
            text: 2000,
            embed:[ {
                desc: 2048,
                field: 1024,
                foot: 2048,
                author: 256
            },6000]
        }
        this.prefix = prefix
        this.suffix = suffix
        return function(page) {
                let Page = this.autoPage(page);
                return this.sendPage(Page);
        }
    }

    addPage(index,page) {
        this.pages.splice(index,0,page)
    }

    autoPage(message) {
        return message
    }

    sendPage(page) {

    }
}

page = new Paginator()
page()