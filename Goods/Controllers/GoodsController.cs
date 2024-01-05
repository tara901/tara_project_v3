using AutoMapper;
using Goods.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoodsCore.Models;

namespace Goods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsController : Controller
    {
        private GoodAppContext _context;

        private readonly IMapper _mapper;

        public GoodsController(IMapper mapper, GoodAppContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut]
        public void Put([FromBody] GoodsAddDto model)
        {
            var goods = _mapper.Map<GoodsAddDto, Good>(model);

            _context.Goods.Add(goods);
            _context.SaveChanges();
        }

        [HttpPost]
        public void Post(GoodsEditDto student)
        {
            var existStudent = _context.Goods.FirstOrDefault(x => x.Id == student.Id);

            if (existStudent != null)
            {
                _mapper.Map(student, existStudent);

                _context.Goods.Update(existStudent);
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetOne")]
        public GoodsGetDto? Get(int id)
        {
            var goods = _context.Goods.Include(p => p.Group).FirstOrDefault(x => x.Id == id);

            if (goods == null) return null;

            return GoodsGetDto(goods);
        }

        [HttpPost]
        [Route("GetAll")]
        public GoodsGetAllDto GetAll([FromBody] GoodsFilterDto filter)
        {
            var query = _context.Goods.AsQueryable();

            if (filter.NameGoods != null)
            {
                query = query.Where(x => x.NameGoods.Contains(filter.NameGoods));
            }

            if (filter.ProductCategory != null)
            {
                query = query.Where(x => x.ProductCategory.Contains(filter.ProductCategory));
            }

            if (filter.GroupId != null)
            {
                query = query.Where(x => x.GroupId == filter.GroupId);
            }

            var Goods = query.ToList()
                .Select(goods => GoodsGetDto(goods))
                .ToList();

            var model = new GoodsGetAllDto
            {
                Goods = Goods,
                Groups = _context.Groups.Select(x => new GroupDto { Id = x.Id, Name = x.Name }).ToList()
            };

            return model;
        }

        private GoodsGetDto GoodsGetDto(Good goods)
        {
            var result = _mapper.Map<GoodsGetDto>(goods);

            return result;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var goods = _context.Goods.FirstOrDefault(x => x.Id == id);

            if (goods != null)
            {
                _context.Goods.Remove(goods);
                _context.SaveChanges();
            }
        }
    }
}
