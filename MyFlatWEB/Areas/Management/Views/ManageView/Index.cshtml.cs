﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFlatWEB.Areas.Identity.Pages.Account.Manage
{
    public partial class Index : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public Index(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadAsync(user);
        //        return Page();
        //    }

        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        //    if (Input.PhoneNumber != phoneNumber)
        //    {
        //        var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
        //        if (!setPhoneResult.Succeeded)
        //        {
        //            StatusMessage = "Unexpected error when trying to set phone number.";
        //            return RedirectToPage();
        //        }
        //    }

        //    await _signInManager.RefreshSignInAsync(user);
        //    StatusMessage = "Your profile has been updated";
        //    return RedirectToPage();
        //}
    }
}