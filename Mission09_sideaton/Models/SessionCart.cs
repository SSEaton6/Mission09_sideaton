using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_sideaton.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission09_sideaton.Models
{
    public class SessionCart : ShoppingCart
    {

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
