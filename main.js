const Discord = require("discord.js");
const Message = Discord.Message;

const cp = require("child_process");
const wt = require("worker_threads");
const ah = require("async_hooks");

class Jshaku {
    constructor(owners = []) {
        this.owners = owners;
        this.version = "1.0.0";
        return function(user) {
            return Message.channel.send(`${user.name} ${this.owners.includes(user) ? "does" : "does not"} have access to the jshaku plugin ${Jshaku.verison}`)
        }
    }

    sh(ctx, command = "", args = [""], options = {
                cwd: "./",
                detached: false,
                env: process.env,
                shell: true
            }) {
        try {
            const task = cp.spawn(command, args, options);
        } catch (e) {
            return message.channel.send(e)
        }
    }

    su(user, command, ...args) {

    }

    async js(ctx=message.channel, cmd="") {
        await ctx.send(`\`\`\`${await eval(cmd)}\`\`\``);
    }

}


module.exports = Jshaku;