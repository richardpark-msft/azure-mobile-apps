using System;
using System.Collections.Generic;
using System.Windows.Input;
using Bogus;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinFormsBlogClient.Models;

namespace XamarinFormsBlogClient.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public List<BlogPost> BlogPosts { get; set; }
        public string AvatarUrl { get; set; }
        public HomeViewModel()
        {
            Title = "Home";

            AvatarUrl = new Faker().Internet.Avatar();

            var testBlogPosts = new Faker<BlogPost>()
                .RuleFor(x => x.Title, t => t.Lorem.Sentence())
                .RuleFor(x => x.Data, d => d.Lorem.Paragraphs(4))
                .RuleFor(x => x.CommentCount, c => c.Random.Number(0, 100))
                .RuleFor(x => x.ShowComments, s => s.Random.Bool())
                .RuleFor(x => x.ImageUrl, i => i.Image.PicsumUrl());

            var blogPosts = testBlogPosts.Generate(20);

            BlogPosts = blogPosts;
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}