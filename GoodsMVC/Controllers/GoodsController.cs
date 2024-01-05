using Goods.Models;
using GoodsCore.Models;
using GoodsMVC.Models;
using GoodsMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace GoodsMVC.Controllers
{
    public class GoodsController : Controller
    {
        private readonly HttpClientService _httpClientService;

        public GoodsController(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index(GoodsFilterDto filter)
        {
            var model = await _httpClientService.Post<GoodsFilterDto, GoodsGetAllDto>("/Goods/GetAll", filter);

            var viewModel = new GoodsViewModel
            {
                Goods = model.Goods,
                Groups = model.Groups,
                Filter = filter
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _httpClientService.Delete($"/Goods?id={id}");

            return RedirectToAction(nameof(Index));

            //return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GoodsAddDto goods)
        {
            await _httpClientService.Put("/Goods", goods);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await GetGroups();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GoodsEditDto goods)
        {
            await _httpClientService.Post("/Goods", goods);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using HttpClient client = new HttpClient();

            var model = new GoodsEditViewModel
            {
                Goods = await _httpClientService.Get<GoodsGetDto>($"/Goods/GetOne?id={id}"),

                Groups = await GetGroups()
            };

            return View(model);
        }

        private async Task<List<GroupDto>> GetGroups()
        {
            var model = await _httpClientService.Post<GroupFilterDto, List<GroupDto>>("/Group/GetAll", new GroupFilterDto());

            return model;
        }
    }
}