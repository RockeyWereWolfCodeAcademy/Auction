using Auction.Business.DTOs.CategoryDTOs;
using Auction.Business.Exceptions.Category;
using Auction.Business.Exceptions.Common;
using Auction.Business.Repositories.Interfaces;
using Auction.Business.Services.Interfaces;
using Auction.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Implements;

public class CategoryService : ICategoryService
{
    readonly ICategoryRepository _repo;
    readonly IMapper _mapper;

    public CategoryService(ICategoryRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task CreateAsync(CategoryCreateDTO dto)
    {
        if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
            throw new CategoryExistException();
        if (!await _repo.IsExistAsync(r => r.Id == dto.ParentCategoryId))
            if (dto.ParentCategoryId != null)
                throw new NotFoundException<Category>("Parent category is not found");
        await _repo.CreateAsync(_mapper.Map<Category>(dto));
        await _repo.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _checkId(id);
        _repo.Delete(data);
        await _repo.SaveAsync();
    }

    public IEnumerable<CategoryListDTO> GetAll()
        => _mapper.Map<IEnumerable<CategoryListDTO>>(_repo.GetAll(includes: "ChildCategories"));
    public async Task<CategoryDetailsDTO> GetByIdAsync(int id)
    {
        var data = await _checkId(id, true);
        var dto = _mapper.Map<CategoryDetailsDTO>(data);
        return dto;
    }

    public async Task UpdateAsync(int id, CategoryUpdateDTO dto)
    {
        var data = await _checkId(id);
        if (dto.Name.ToLower() != data.Name.ToLower())
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new CategoryExistException();
        if (!await _repo.IsExistAsync(r => r.Id == dto.ParentCategoryId))
            if (dto.ParentCategoryId != null)
                throw new NotFoundException<Category>("Parent category is not found");
        data = _mapper.Map(dto, data);
        await _repo.SaveAsync();    
    }

    public async Task SoftDelete(int id)
    {
        var data = await _checkId(id);
        data.IsDeleted = true;
        await _repo.SaveAsync();
    }

    public async Task ReverseSoftDelete(int id)
    {
        var data = await _checkId(id);
        data.IsDeleted = false;
        await _repo.SaveAsync();
    }

    async Task<Category> _checkId(int id, bool isTrack = false)
    {
        if (id <= 0) throw new ArgumentException();
        var data = await _repo.GetByIdAsync(id, isTrack, includes: "ChildCategories");
        if (data == null) throw new NotFoundException<Category>();
        return data;
    }
}
