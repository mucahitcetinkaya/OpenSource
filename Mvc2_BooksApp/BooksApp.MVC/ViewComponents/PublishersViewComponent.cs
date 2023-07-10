using BooksApp.Business.Abstract;
using BooksApp.Entity.Concrete;
using BooksApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.MVC.ViewComponents
{
    public class PublishersViewComponent:ViewComponent
    {
        private readonly IPublisherService _publisherManager;

        public PublishersViewComponent(IPublisherService publisherManager)
        {
            _publisherManager = publisherManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Publisher> publisherList = await _publisherManager.GetAllAsync();
            List<PublisherViewModel> publisherViewModelList = publisherList.Select(p => new PublisherViewModel
            {
                Name=p.Name,
                Url=p.Url
            }).ToList();
            return View(publisherViewModelList);
        }
    }
}
