using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using webui.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer("Server=DESKTOP-MON9CEU\\SQLEXPRESS;Database=FWorld;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
                                                                                    //bensersiz bir sayi verilecek(parolama resetleme gibi islemler icin)

builder.Services.Configure<IdentityOptions>(options=>{ // !!!!!!!!!!

    //password
     options.Password.RequireDigit=false; // rakam icermek
     options.Password.RequireLowercase=false; //kucuk harf 
     options.Password.RequireUppercase=false; //buyuk harf
     options.Password.RequiredLength=6;
     options.Password.RequireNonAlphanumeric=true; //alphanumeric karakter

    // Lockout  //kullanici hesap kitleme
    options.Lockout.MaxFailedAccessAttempts=20; // 5 deneme hakki sonra kitlenir
    options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(5); // 5 dakika sonra kilit acılır
    options.Lockout.AllowedForNewUsers  = true; //lockout aktif olmasi icin


    //User
    // options.User.AllowedUserNameCharacters=""; //userin username icermesi gereken karakterler
    options.User.RequireUniqueEmail=true; //her email farkli

    // Sıgn in
    options.SignIn.RequireConfirmedEmail=true; // maile gidep onayi yapmalı
    // options.SignIn.RequireConfirmedPhoneNumber=true; // tel icin onay
});

builder.Services.ConfigureApplicationCookie(options=>{

    options.LoginPath= "/Account/Login";  //cookie yoksa buraya yetkisi yoksa bu path'e gidiyo
    options.LogoutPath="/Account/Logout";
    options.AccessDeniedPath="/Account/Accsesdenied"; // yetki kontrolu erisim engelleme
    options.SlidingExpiration=true; // cookie suresi login yapıldıgında yenilenir
    options.ExpireTimeSpan=TimeSpan.FromMinutes(15); // cookie 40 dakika boyunca saklanır (40 dk boyunca login gerekmez)
    options.Cookie=new CookieBuilder
    {
        HttpOnly=true, // cookie sadece http talebine cevap verir // herhangi bir script buna erisemesin diye
        Name=".FWorld.Security.Cookie"
    };    

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
