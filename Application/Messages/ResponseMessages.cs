using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messages
{
    public static class ResponseMessages
    {
        /*
            Front-end de eğer localization eklersek bunlar key olucak ve bunları json da map ederek backend 
            mesajlarını localize etmiş olucaz
         */
        //Shared Messages
        public static readonly string Shared_PleaseFillTheRequiredFields = "Backend.PleaseFillTheRequiredFields";

        //Auth Service Messages
        public static readonly string Auth_AuthUnauthorized = "Backend.Unauthorized";
        public static readonly string Auth_AuthUserNotFound = "Backend.UserNotFound";

        // Brand Service Messages
        public static readonly string Brand_NameCountryRequired = "Backend.NameAndCountryIsRequired";
        public static readonly string Brand_BrandAlreadyExists = "Backend.BrandAlreadyExists";
        public static readonly string Brand_BrandDoesNotExists = "Backend.BrandDoesNotExists";

        //Fragrance Service Messages
        public static readonly string Fragrance_FragranceDoesNotExists = "Backend.FragranceDoesNotExists";
        public static readonly string Fragrance_FragranceAlreadyExists = "Backend.FragranceAlreadyExists";

        //Comment Service Messages
        public static readonly string Comment_CommentDoesNotExists = "Backend.CommentDoesNotExists";
        public static readonly string Comment_CommentAlreadyExists = "Backend.CommentAlreadyExists";

        //Creator Service Messages
        public static readonly string Creator_CreatorDoesNotExist = "Backend.CreatorDoesNotExist";
        public static readonly string Creator_CreatorAlreadyExist = "Backend.CreatorAlreadyExist";

        //FragranceNote Service Messages
        public static readonly string FragranceNote_FragranceNoteDoesNotExist = "Backend.FragranceNoteDoesNotExist";
        public static readonly string FragranceNote_FragranceNoteAlreadyExist = "Backend.FragranceNoteAlreadyExist";

        //Rating Service Messages
        public static readonly string Rating_RatingDoesNotExist = "Backend.RatingDoesNotExist";
        public static readonly string Rating_RatingAlreadyExist = "Backend.RatingAlreadyExist";

        //User Service Messages
        public static readonly string User_UserDoesNotExist = "Backend.UserDoesNotExist";
        public static readonly string User_UserAlreadyExist = "Backend.UserAlreadyExist";

        //Article Service Messsages
        public static readonly string Article_ArticleDoesNotExist = "Backend.ArticleDoesNotExist";
    }
}
