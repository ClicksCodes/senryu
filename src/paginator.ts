import { MessageEmbed } from 'discord.js';

export class PaginatorEmbed {
  	private _pages: MessageEmbed[];
  	private _currentPage: number;

  	constructor(pages: MessageEmbed[]) {
		this._pages = pages;
		this._currentPage = 0;
	}

	get currentPage() {
		return this._currentPage;
	}

	get pages() {
		return this._pages;
	}
	
    next() {
        this._currentPage++;
        if (this._currentPage == this._pages.length) {
			this._currentPage = 0;
		}
    }

    prev() {
        this._currentPage--;
        if (this._currentPage == -1) {
            this._currentPage = this._pages.length - 1;
        }
    }

    goto(page: number) {
        if (page >= 0 && page < this._pages.length) {
            this._currentPage = page;
        }
    }
    
	repr() {
        return this._pages[this._currentPage];
    }
}

export class Paginator extends PaginatorEmbed {
	private _pages: string[];
	private _currentPage: number;

	constructor(pages: string[]) {
		super();
		this._pages = pages;
		this._currentPage = 0;
	}

	get currentPage() {
		return this._currentPage;
	}

	get pages() {
		return this._pages;
	}
	
	next() {
		this._currentPage++;
		if (this._currentPage == this._pages.length) {
			this._currentPage = 0;
		}
	}

	prev() {
		this._currentPage--;
		if (this._currentPage == -1) {
			this._currentPage = this._pages.length - 1;
		}
	}

	goto(page: number) {
		if (page >= 0 && page < this._pages.length) {
			this._currentPage = page;
		}
	}
	
	repr() {
		return this._pages[this._currentPage];
	}
}