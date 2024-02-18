export class UrlForShortModel{
    longUrl: string = '';
    code: string = '';
    userId: string = '';
}

export class UrlModel{
    id: string = ''
    longUrl: string = '';
    shortUrl: string = '';
    code: string = ''; 
    dateOfCreation: Date = new Date(); 
    userId: string = '';
}

export class ShortenerUrl{
    shortenerUrl: string  = '';
}