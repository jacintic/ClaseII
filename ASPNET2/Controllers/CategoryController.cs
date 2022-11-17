﻿using Microsoft.AspNetCore.Mvc;


namespace ASPNET2.Controllers;


[ApiController]
[Route("api/categories")]
public class CategoryController
{
    private ICategoryRepository CatRepo;

    public CategoryController(ICategoryRepository catRepository)
    {
        CatRepo = catRepository;
    }


    // API Methods
    // https://localhost:7230/api/books/1
    [HttpGet("{id}")]
    public Category FindById(int id)
    {
        return CatRepo.FindById(id);
    }


    // https://localhost:7230/api/books/findall
    [HttpGet]
    public List<Category> FindAll()
    {
        return CatRepo.FindAll();
    }
}