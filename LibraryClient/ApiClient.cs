using System;
using System.Numerics;
using System.Text;
using LibraryBot.Models;
using LibraryBot.Responce;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace LibraryBot.LibraryClient
{
    public  class ApiClient
    {
        readonly  HttpClient _client;
        private  string _adress;

        public  ApiClient()
        {
            _adress = Config.ApiURL;


            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
        }
        public async Task<Books> GetBooks()
        {
            var response = await _client.GetAsync("GetBooks");
            response.EnsureSuccessStatusCode();
            
             var content = response.Content.ReadAsStringAsync().Result;
             var books = JsonConvert.DeserializeObject<Books>(content);

            return books;
        }
        public async Task<Book> GetBook(string key,string title)
        {
            var response = await _client.GetAsync($"GetBook?key={key}&id={title}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            var content = response.Content.ReadAsStringAsync().Result;
            var book = JsonConvert.DeserializeObject<Book>(content);

            return book;

        }
        public async Task<bool> ReserveBook(string title)
        {
            var book = await GetBook("Title",title);
            if (book == null)
                return false;
            if (book.Status == "Available")
            {
                var put = await _client.PutAsync($"UpdateStatus?action=Reserve&id={book.Id}", null);
                if (put.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
            }
            return false;

            
        }
        public async Task<bool> ReturnBook(string title)
        {
            var book = await GetBook("Title", title);
            if (book == null)
                return false;
            if (book.Status != "Available")
            {

                var put = await _client.PutAsync($"UpdateStatus?action=Return&id={book.Id}", null);
                if (put.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
            }
            return false;


        }
        public async Task<bool> BorrowBook(string title)
        {

            var book = await GetBook("Title", title);
            if (book == null)
                return false;
            if (book.Status != "Borrowed")
            {

                var put = await _client.PutAsync($"UpdateStatus?action=Borrow&id={book.Id}", null);
                if (put.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
            }
            return false;


        }
        public async Task<bool> PostBook(PostResponce postResponce)
        {
            var json = JsonConvert.SerializeObject(postResponce);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var post = await _client.PostAsync($"PostBook?Title={postResponce.Title}&Author={postResponce.Author}&Status={postResponce.Status}&Publisher={postResponce.Publisher}&Isbn={postResponce.Isbn}&Genre={postResponce.Genre}&Date={postResponce.Date}", data);
            if (post.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}

