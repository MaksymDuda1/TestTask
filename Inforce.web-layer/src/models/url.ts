export class UrlForShortModel{
    longUrl: string = '';
    code: string = '';
}

export class UrlModel{
    id: string = ''
    longUrl: string = '';
    shortUrl: string = '';
    code: string = ''; 
    dateOfCreation: Date = new Date(); 
}

export class ShortenerUrl{
    shortenerUrl: string  = '';
}