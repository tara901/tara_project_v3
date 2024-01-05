using Microsoft.AspNetCore.Mvc;
using GoodsCore.Models;
using GoodsMVC.Models;
using GoodsMVC.Services;
using Goods.Models;
using System.Net.Http.Json;

namespace GoodsMVC.Controllers
{
    public class GroupController : Controller
    {
        private readonly HttpClientService _httpClientService;

        public GroupController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index(GroupFilterDto filter)
        {

            var groups = await _httpClientService.Post<GroupFilterDto, List<GroupDto>>("/Group/GetAll", filter);

            var viewModel = new GroupViewModel
            {
                Filter = filter,
                Groups = groups
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClientService.Delete($"/Group?id={id}");

            return RedirectToAction(nameof(Index));

            //return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name)
        {
            var group = new GroupDto { Name = name };

            await _httpClientService.Put("/Group", group);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string name)
        {
            var group = new GroupDto { Id = id, Name = name };

            await _httpClientService.Post("/Group", group);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _httpClientService.Get<GroupDto>($"/Group/GetOne?id={id}");

            return View(model);
        }
    }
}

