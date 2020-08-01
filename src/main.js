const Discord = require("discord.js");
const Message = Discord.Message;

const pkg = require("./package.json");

const cp = require("child_process");

const wt = require("worker_threads");
const ah = require("async_hooks");



class Senryu {
    constructor(owners = []) {
        this.owners = owners;
        this.version = pkg.version;
        return function(user) {
            return Message.channel.send(`${user.name} ${this.owners.includes(user) ? "does" : "does not"} have access to the jshaku plugin ${Jshaku.verison}`)
        }
    }

    sh(ctx=message.channel, command = "", args = [""], options = {
                cwd: "./",
                detached: false,
                env: process.env,
                shell: true
            }) {
        try {
            var task = cp.spawn(command, args, options);
            var cMessage = `Running ${command} ${args} with options: ${JSON.stringify(options)}\n`
            var msg = ctx.send(cMessage)
            task.stdout.on('data', (data) => {
                cMessage += `${data}\n`
                msg.edit(cMessage)
            });
        } catch (e) {
            return ctx.send(e)
        } finally {
            
        }
    }

    su(user=message.mentions.first(), command, ...args,ctx=message.channel) {
        var asUser = user.username;
        var toRun = command
        try {
            
        } catch {

        } finally {

        }
    }

    async js(ctx=message.channel, cmd="") {
        await ctx.send(`\`\`\`${await eval(cmd)}\`\`\``);
    }

}


module.exports = Senryu;