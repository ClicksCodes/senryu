import { MessageEmbed } from 'discord.js';

export const log = console.log();

export const URL_RE = /[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)?/;

export function isUrl(str: string) {
  return URL_RE.test(str);
}



export const injectAuthor = (embed: MessageEmbed):MessageEmbed => {
	if (embed.author) return embed;
	return embed.setAuthor({
		name: process.env.BOT_NAME,
		icon_url: process.env.BOT_AVATAR,
	});

}

export const injectFooter = (embed: MessageEmbed):MessageEmbed => {
	if(embed.footer) {
		return embed;
	}
	return embed.setFooter({
		text: process.env.DEFAULT_FOOTER,
		icon_url: process.env.BOT_AVATAR,
	});
}

export const formatEmbed = (embed: MessageEmbed):MessageEmbed => {
	return injectAuthor(injectFooter(embed));
}