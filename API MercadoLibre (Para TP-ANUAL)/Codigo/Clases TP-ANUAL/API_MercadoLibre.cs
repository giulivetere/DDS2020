///////////////////////////////////////////////////////////
//  Mundo.cs
//  Implementation of the Class Mundo
//  Generated by Enterprise Architect
//  Created on:      04-Sep-2020 11:29:31 PM
//  Original author: Ignacio Andre Keiniger
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using API_MercadoLibre;

namespace API_MercadoLibre {
	public class API_MercadoLibre { // Convertir en singleton

		public List<Pais> paises;

		public API_MercadoLibre(){
            // Si ya hay algo, me aseguro que se vac�e
            paises = new List<Pais> { };

            // Lista actual de IDs de paises en la API
            List<string> id_paises = new List<string> { };

            // Pido a la api la lista de paises
            WebRequest request_id = HttpWebRequest.Create("https://api.mercadolibre.com/classified_locations/countries/");
            WebResponse response_id = request_id.GetResponse();
            StreamReader reader_id = new StreamReader(response_id.GetResponseStream());

            // Guardo el JSON leido en un objeto
            string JSON_ids = reader_id.ReadToEnd();
            List<ML_CountrySmall> objetoCountrySmall = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ML_CountrySmall>>(JSON_ids);

            // Agrego los IDs a la lista id_paises
            foreach (ML_CountrySmall pais in objetoCountrySmall)
            {
                id_paises.Add(pais.id);
            }

            // Recorro la lista de IDs de paises y agrego cada uno a la lista "Paises" de Mundo
            foreach (string id in id_paises)
            {
                paises.Add(new Pais(id));
            }
        }
	}
}