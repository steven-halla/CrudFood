using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudFood.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudFood.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<DishRecipe> AllDishes = _context.DishRecipes.ToList();
            

            return View(AllDishes);
        }

        [HttpGet]
        [Route("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateNewRecipe")]
        public IActionResult CreateNewRecipe(DishRecipe newRecipe)
        {   
            if(ModelState.IsValid)
            {
            _context.DishRecipes.Add(newRecipe);
            _context.SaveChanges();

            return RedirectToAction("Index");
            }
            else{
                return View("New");
            }
        }

        [HttpGet]
        [Route("{DishRecipeId}")]
        public IActionResult Info(int DishRecipeId)
        //when trying to frame one item in a liist, use FirstOrDefualt, do not use ToList() and don't use Where 
        //because Where is a filter
        {
            DishRecipe dish  = _context.DishRecipes.FirstOrDefault(dish => dish.DishRecipeId == DishRecipeId);
            return View("Info",dish);
            // info is the cshtml page, dish is the model
        }

        [HttpPost]
        [Route("deletedish")]
        public IActionResult Delete(int DishRecipeId)
        {
            DishRecipe badDish = _context.DishRecipes.FirstOrDefault(badDish => badDish.DishRecipeId == DishRecipeId);
            _context.DishRecipes.Remove(badDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{DishRecipeId}")]
        public IActionResult EditPage(int DishRecipeId)
        {
            DishRecipe editDish = _context.DishRecipes.FirstOrDefault(editDish => editDish.DishRecipeId == DishRecipeId);
            Console.WriteLine(editDish.Name);
            return View("Edit", editDish);

        }

        [HttpPost]
        [Route("edit/{DishRecipeId}")]
        public IActionResult Edit(DishRecipe EditedDish, int DishRecipeId)
        {
            
            if(ModelState.IsValid)
            {
                Console.WriteLine(_context.DishRecipes.LongCount());
                DishRecipe editDish = _context.DishRecipes.FirstOrDefault(editDish => editDish.DishRecipeId == DishRecipeId);
                Console.WriteLine("{0} {1}", editDish.Name, EditedDish.Name);
                editDish.Name = EditedDish.Name;
                editDish.Chef = EditedDish.Chef;
                editDish.Calories = EditedDish.Calories;
                editDish.Tastiness = EditedDish.Tastiness;
                editDish.Description = EditedDish.Description;
                _context.DishRecipes.Update(editDish);
                _context.SaveChanges();
                return RedirectToAction("Edit");

            }   
                return View("Edit", EditedDish);

        }
        

    }
}


