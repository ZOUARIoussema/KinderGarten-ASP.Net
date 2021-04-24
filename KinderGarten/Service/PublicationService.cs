﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class PublicationService
	{
        HttpClient httpClient;
        public PublicationService()
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public Boolean Add(Publication publication)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Publication>(Statics.baseAddress + "parent/addPublication/",
                    publication).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Publication> getAllPublicationDesc()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getAllPublicationDesc").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                var pub = response.Content.ReadAsAsync<IEnumerable<Publication>>().Result;

                return pub;
            }

            return new List<Publication>();

        }
        public Publication GetById(int id)
        {

            Publication publication = null;

            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getPublicationById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var pub = response.Content.ReadAsAsync<Publication>().Result;

                return pub;
            }


            return publication;

        }
        public bool UpdatePublication(Publication publication)
        {


            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Publication>(Statics.baseAddress + "parent/updateDescription/" + publication.Parent,
                 publication).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool DeletePublication(int id)
        {

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "parent/deletePublicationById/" + id);

                return true;
            }
            catch
            {
                return false;
            }


        }




    }
}