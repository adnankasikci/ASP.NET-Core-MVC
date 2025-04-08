using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppSpace.Helpers
{
    public static class SwiperAlert
    {
        public static void ShowSweetAlert(Controller controller, string title, string message, string type = "success", string color = "#3085d6", string redirectUrl = "/")
        {
            var alertData = new Dictionary<string, object>
            {
                { "SwalTitle", title },
                { "SwalMessage", message },
                { "SwalType", type },
                { "SwalColor", color },
                { "SwalRedirect", redirectUrl }
            };

            controller.TempData["SwalAlertData"] = alertData;

        }
    }
}
