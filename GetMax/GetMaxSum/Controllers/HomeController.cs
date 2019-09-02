using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetMaxSum.Models;

namespace GetMaxSum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new GetMaxModel{
                IsResult = false,
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create(GetMaxModel getmaxmodel)
        {
            var model = new GetMaxModel{
                ObjectNumber = getmaxmodel.ObjectNumber,
                IsResult = false,
            };
            return View(nameof(Index), model);
        }
        public IActionResult GetMax(GetMaxModel getmaxmodel)
        {
            var stringResult = "";
            string bestchoice = "";
            int maxSum = 0;
            for (int number = 0; number < getmaxmodel.ObjectNumber; number++)
            {
                if (getmaxmodel.ObjectValues[number] > maxSum)
                {
                    maxSum = getmaxmodel.ObjectValues[number];
                    bestchoice = $"{getmaxmodel.ObjectValues[number]} = {maxSum}";
                }
                stringResult += $"{getmaxmodel.ObjectValues[number]} = {getmaxmodel.ObjectValues[number]} ou ";
                for (int i = number + 2; i < getmaxmodel.ObjectNumber; i++)
                {
                    int jump = 2;
                    while (jump <= getmaxmodel.ObjectNumber)
                    {
                        int sum = getmaxmodel.ObjectValues[number];
                        stringResult += $"{getmaxmodel.ObjectValues[number]}, ";
                        var choice = $"{getmaxmodel.ObjectValues[number]}, ";

                        int j = i;
                        int countJump = 0;
                        while (j < getmaxmodel.ObjectNumber)
                        {
                            sum += getmaxmodel.ObjectValues[j];
                            stringResult += $"{getmaxmodel.ObjectValues[j]}, ";
                            choice += $"{getmaxmodel.ObjectValues[j]}, ";
                            j += jump;
                            countJump++;
                        }
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            bestchoice = $"{choice.Substring(0, choice.Length - 2)} = {maxSum}";
                        }
                        stringResult = $"{stringResult.Substring(0, stringResult.Length - 2)} =  {sum} ou ";
                        jump++;
                        if (countJump == 1)
                            break;
                    }

                }
            }
            

            var model = new GetMaxModel{
                ObjectNumber = getmaxmodel.ObjectNumber,
                ObjectValues = getmaxmodel.ObjectValues.ToList(),
                IsResult = true,
                ResultString = stringResult.Substring(0, stringResult.Length - 4),
                BestChoice = $"Le meilleur choix est {bestchoice}",
            };
            return View(nameof(Index), model);
        }
    }
}
