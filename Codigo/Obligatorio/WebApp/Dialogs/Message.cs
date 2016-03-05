using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Dialogs
{
    public class Message
    {
        /// <summary>
        /// Crea un dialogo
        /// </summary>
        /// <param name="id">Nombre del div</param>
        /// <param name="title">Titulo del div</param>
        /// <param name="text">Texto que se va a mostrar</param>
        /// <returns>Div con los datos pasados</returns>
        public static String createDialog(string id, string title, string text)
        {
            string result = String.Empty;
            result += "<div id='";
            result += id;
            result += "' class='dialog' style='display: none;'  title=";
            result += title;
            result += "><p>";
            result += text;
            result += "</p></div>";
            return result;

        }
    }
}