using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text;
using WEB.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("https://investidor10.com.br");
        public ResumoDTO resumoDTO = new ResumoDTO();
        private const string SessionIdCarteira = "SessionIdCarteira";
        private const string SessionCarteira = "SessionCarteira";

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            resumoDTO = JsonConvert.DeserializeObject<ResumoDTO>(HttpContext.Session.GetString(SessionCarteira) ?? string.Empty) ?? new ResumoDTO();

            if (resumoDTO.Iniciado)
            {
                return View(true);
            }
            else
            {
                return View(false);
            }
        }

        public IActionResult CarregaDados(string idCarteira)
        {
            var _idCarteira = HttpContext.Session.GetString(SessionIdCarteira) ?? string.Empty;
            resumoDTO = JsonConvert.DeserializeObject<ResumoDTO>(HttpContext.Session.GetString(SessionCarteira) ?? string.Empty) ?? new ResumoDTO();
            var cookie = "ads_popup=eyJpdiI6IktXWWpuYmpHbXFxQWhlNlovbVlvVHc9PSIsInZhbHVlIjoid1NEV0ZrOER5a1BTMU9VSnZYSmlhbHZxVlZBNFUwVzluTzlLR1dCRWZsYm5nU0l3SDBwcTltSS81QitBZTMwWklTRytMVEN1a2REU2ljcEs5U3BQS0luRmloeXd1Tlgva2NZZm1YbVVqV1k9IiwibWFjIjoiNWM5N2U0NWMzZDcxMzRhY2JjNTJhOTU4MDM4YTg0NTFlODAwNGM0N2QxZmExOTM2MDRhYmMzZWNjMTFmZTllNyJ9; sib_cuid=2eb71b24-0d30-478e-9f7f-14845f1a2ff7; SLG_G_WPT_TO=pt; _fbp=fb.2.1711243835452.776130160; SLG_GWPT_Show_Hide_tmp=1; SLG_wptGlobTipTmp=1; _gcl_au=1.1.181278894.1711243843; _hjSessionUser_2058627=eyJpZCI6IjRhNGU2MmQ5LTUyZDMtNTJlMC04ZTdlLWU4MmZlOGFiZmM5NyIsImNyZWF0ZWQiOjE3MTEyNDQxODUyMzgsImV4aXN0aW5nIjp0cnVlfQ==; counter_pro=1711450640185; buy_and_hold=5; _uetvid=3a091730eb5811eea408db95503cba0d; blueID=b70e7765-08b3-4576-9eb7-69e818325628; _ga_3TXVTJSHD7=GS1.1.1711447465.1.0.1711447467.58.0.0; _ga_5EQ309XQDG=deleted; _ga_267511960=deleted; zabUserId=1712255828296zabu0.9642663688227961; zps-tgr-dts=sc%3D1-expAppOnNewSession%3D%5B%5D-pc%3D1-sesst%3D1712255828526; zpsfa_CrrM31V=1712255828708psf0.30054752858981804; _ce.irv=new; cebs=1; _CEFT=Q%3D%3D%3D; _gid=GA1.3.949093057.1713170665; pro_ref_v2=eyJpdiI6Ik8xcTZqN2N6Z1B0TEtKWVhCSjRaUlE9PSIsInZhbHVlIjoiTHBjYW1WVENJMDhsRGkySHMxckJVT3lwcnZrRE5LYnVUekkxR3h1RHljS0JpcjBoYlpjOGh0VVVPNVo1N2xmUSIsIm1hYyI6IjcwMWYyZGMxODM1ZTI0NTA3MjYxYWNiMTBiYzAzOGI1MDNiMzRhMjA4NGIzYTI1ZGY5ZjQxYjBkNmI2NmMxNGIifQ%3D%3D; cookie_contador_whole-site=eyJpdiI6IjJFelkwRGVDZlZpRm9WcmJtYUxJYUE9PSIsInZhbHVlIjoiaURKWlZrT20rQmo1L3JVd2k4QkZKZHBrTW41SFdFbWxKcitCM05JT05SS0RZdVBkQ1Fac1VuaTZGYlNURFFNOFpsU3pya0lnV3QzZmxLMVByTXhBMmc9PSIsIm1hYyI6ImIyY2M3Yjk2ODJlZmQxOWVhNTI5MmIzZDA0OTYzOTVkZjc4OTVjOGZiNDdhYzk2ZjJkNzMxNDE3MWI4NmY1MTcifQ%3D%3D; _ce.clock_event=1; _ce.clock_data=65%2C109.51.218.16%2C1%2C36489d387fc8bef5e6ceaf2293b7a987; cookie_contador_carteira=eyJpdiI6ImNHZncrdFBOK0Q0a2gzZUZ5M0h4QWc9PSIsInZhbHVlIjoiWFcyZUFKMHQwdEl0Z2swS3J4UmY1b2Q4dkwvdlRUTnc1SVFUL1pLeWVPNFFGN2E1UlgrMlNydENjSm9yQXB1RjBSKzdLZDZ2V0lSMnpzNWNkRGVuQVE9PSIsIm1hYyI6IjljOThkYTAxYTU3M2Y2ZDU1NDY3NzU0MzNmNTI1MTQ3YTM3MTIxZWRjM2RmOTU3M2NmZDMxYTRhZjg1MTg0NjYifQ%3D%3D; g_state={\"i_l\":0,\"i_t\":1713364221916}; remember_web_59ba36addc2b2f9401580f014c7f58ea4e30989d=eyJpdiI6IkxPaThrZ2FqeTMwc3ZHMnpCM0JmQkE9PSIsInZhbHVlIjoic09aUWFxOG4wV1RlRDhhUWE2bTM1MTBMQWNZTkwzdDNHZVBydVdkRWtVQW5uMnpFR25XVlhwZDRXZTdGcDZTUVQyQUordVpZZVJvZEM0Y3V3QWt3MGZlWm9Pd3k1VjNQTUZ4QnhNUkVmTU52TEpnTTluTHlYWW1adUVJQlNBUXcyOUU3TzFGQ0R1dlRLNFY3bE1QVHpJTENvaHhBM3Z1eWdYRGRMaXFrUUUxU1RwTUYyOEN5UTdxYnYxanU4Smh3dkl4UStmK0tybXd0RnFQREdsMmdLdjhsN00yV1R4V2NJVDV0elRUZGVYST0iLCJtYWMiOiJhYWQ1Njc4Y2Y2NzEyNGZiZTkyOWZmOGFlNjdmN2RkNWEwMGZlNmMwYzI3ODYyM2FlZGE2NWUyZDYyM2Y2Y2ZlIn0%3D; ads_popup=1; __eoi=ID=2a85395afc64ccc0:T=1713288064:RT=1713288064:S=AA-AfjZ8sowQbU2FQT9bY2hYTuNK; cebsp_=163; _ce.s=v~c0ca04eafbf1847c30a89d9d400e0c5448d7713c~lcw~1713288273342~lva~1712305600864~vpv~0~v11.fhb~1713186963499~v11.lhb~1713288247258~gtrk.la~lv2nljs0~v11.cs~442075~v11.s~24df9f30-fc12-11ee-a519-659739d1ef8c~v11.sla~1713288273537~v11.send~1713288273159~lcw~1713288273537; _ga_267511960=GS1.1.1713285054.85.1.1713288274.0.0.0; sc_is_visitor_unique=rx12923067.1713288275.9327AC08AFA94F360B785E0ADF3E47E7.87.62.46.40.28.17.8.2.2; XSRF-TOKEN=eyJpdiI6InQ1bXg4WEUwR0x6U2xDOUFwSkhOQWc9PSIsInZhbHVlIjoiV2xqbTQ1OTVZMm4wOTQ5YTBKOElsUjVVMXhESFNud1d1ZUcxc0lVYnpiZ2xMMlNOZ2ZqRENCVmpNd2NrRC9kSnQ4eXgrUDE3TU5PMWNLdEVmbjdGdmVGNVp4akxCL2cyZ3hzQXVNK05kSWcxVmNDYmZOMGZaVDlDMWZxL2Q1Z3oiLCJtYWMiOiI4NTdmN2VhOTRjMTQ5ZjdiOTE4NTkzZDU1NDA4NDkxNTIxYjEzZWM1NWM4Y2IwMWY3NDNhMGE2MjBjNDczZDMwIn0%3D; laravel_session=eyJpdiI6IjlUTk4welkyVDZ4YlN3bDNMRTVxaGc9PSIsInZhbHVlIjoiYVBxQ0NYSkFqbGo0dzk2cy9rOWgyOStPaVJZSEJIdTBpcUUvRFQ4Vm5WUU5sL1JCOFNkcXZSKzNDSDVBUDdSdjFpQXRKQVI2YUJjeEpTZXNlazVtNlBSUzFQVkw2K1lDemJHUWZRdWF4MHdIVElJOGhtSTVYUkUrc1ZvTzJzZXoiLCJtYWMiOiI4ZmQyZGFlNzM4NjQ5NmRiOWRlMjgxMGY4OTNiMjkxNDQ5MzhiZDIzZDhlZTc4MGQ2NzRlYzgyZTRmNmI0NDMwIn0%3D; _ga_5EQ309XQDG=GS1.1.1713285056.85.1.1713288274.59.0.0; _ga=GA1.3.142919118.1711243835; _gat_gtag_UA_737782_54=1; _hjSession_2058627=eyJpZCI6IjQ1OWYzY2YwLWQwZjAtNGZmYS1iMjk3LTNmMWQ3ODk0OTVmNSIsImMiOjE3MTMyODgyNzQ3MjMsInMiOjAsInIiOjAsInNiIjowLCJzciI6MCwic2UiOjAsImZzIjowLCJzcCI6MH0=";

            if (!resumoDTO.Iniciado || resumoDTO.DataAtualizado.AddMinutes(5) < DateTime.Now || _idCarteira != (idCarteira ?? _idCarteira))
            {
                _idCarteira = string.IsNullOrEmpty(idCarteira) ? _idCarteira : idCarteira;

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/datatable/ativos/" + _idCarteira + "/Ticker");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.Ticker = JsonConvert.DeserializeObject<TickerDTO>(jsonResponse.Result);
                }

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/datatable/ativos/" + _idCarteira + "/Fii");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.Fii = JsonConvert.DeserializeObject<FundoImobiliarioDTO>(jsonResponse.Result);
                }

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/datatable/ativos/" + _idCarteira + "/Etf");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.Etf = JsonConvert.DeserializeObject<TickerDTO>(jsonResponse.Result);
                }

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/proventos/" + _idCarteira + "/all/null/null/all?columns%5B0%5D%5Bdata%5D=category&columns%5B0%5D%5Bname%5D=category&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D%5Borderable%5D=false&columns%5B0%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B0%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=ticker&columns%5B1%5D%5Bname%5D=ticker&columns%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=false&columns%5B1%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B2%5D%5Bdata%5D=qty&columns%5B2%5D%5Bname%5D=qty&columns%5B2%5D%5Bsearchable%5D=true&columns%5B2%5D%5Borderable%5D=false&columns%5B2%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B2%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B3%5D%5Bdata%5D=type&columns%5B3%5D%5Bname%5D=type&columns%5B3%5D%5Bsearchable%5D=true&columns%5B3%5D%5Borderable%5D=false&columns%5B3%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B3%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B4%5D%5Bdata%5D=date_with&columns%5B4%5D%5Bname%5D=date_with&columns%5B4%5D%5Bsearchable%5D=true&columns%5B4%5D%5Borderable%5D=false&columns%5B4%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B4%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B5%5D%5Bdata%5D=date_payment&columns%5B5%5D%5Bname%5D=date_payment&columns%5B5%5D%5Bsearchable%5D=true&columns%5B5%5D%5Borderable%5D=false&columns%5B5%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B5%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B6%5D%5Bdata%5D=value&columns%5B6%5D%5Bname%5D=value&columns%5B6%5D%5Bsearchable%5D=true&columns%5B6%5D%5Borderable%5D=false&columns%5B6%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B6%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B7%5D%5Bdata%5D=total&columns%5B7%5D%5Bname%5D=total&columns%5B7%5D%5Bsearchable%5D=true&columns%5B7%5D%5Borderable%5D=false&columns%5B7%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B7%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B8%5D%5Bdata%5D=net_total&columns%5B8%5D%5Bname%5D=net_total&columns%5B8%5D%5Bsearchable%5D=true&columns%5B8%5D%5Borderable%5D=false&columns%5B8%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B8%5D%5Bsearch%5D%5Bregex%5D=false&start=0&length=30&search%5Bvalue%5D=&search%5Bregex%5D=false&_=1712589650156");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.Proventos = JsonConvert.DeserializeObject<ProventosDTO>(jsonResponse.Result);
                }

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/proventos/" + _idCarteira + "/month/null/null/all");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.Resumo = jsonResponse.Result;
                }

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/charts/diversificacao/" + _idCarteira + "/all");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.Carteira = JsonConvert.DeserializeObject<List<CarteiraDTO>>(jsonResponse.Result);
                }

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/lancamentos/" + _idCarteira + "/1");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.Lancamentos = JsonConvert.DeserializeObject<LancamentosDTO>(jsonResponse.Result);
                }

                using (var handler = new HttpClientHandler { UseCookies = false })
                using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
                {
                    var message = new HttpRequestMessage(HttpMethod.Get, "/api/carteiras/proventos/" + _idCarteira + "/all/null/null/all?columns%5B0%5D%5Bdata%5D=category&columns%5B0%5D%5Bname%5D=category&columns%5B0%5D%5Bsearchable%5D=true&columns%5B0%5D%5Borderable%5D=false&columns%5B0%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B0%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B1%5D%5Bdata%5D=ticker&columns%5B1%5D%5Bname%5D=ticker&columns%5B1%5D%5Bsearchable%5D=true&columns%5B1%5D%5Borderable%5D=false&columns%5B1%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B1%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B2%5D%5Bdata%5D=qty&columns%5B2%5D%5Bname%5D=qty&columns%5B2%5D%5Bsearchable%5D=true&columns%5B2%5D%5Borderable%5D=false&columns%5B2%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B2%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B3%5D%5Bdata%5D=type&columns%5B3%5D%5Bname%5D=type&columns%5B3%5D%5Bsearchable%5D=true&columns%5B3%5D%5Borderable%5D=false&columns%5B3%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B3%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B4%5D%5Bdata%5D=date_with&columns%5B4%5D%5Bname%5D=date_with&columns%5B4%5D%5Bsearchable%5D=true&columns%5B4%5D%5Borderable%5D=false&columns%5B4%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B4%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B5%5D%5Bdata%5D=date_payment&columns%5B5%5D%5Bname%5D=date_payment&columns%5B5%5D%5Bsearchable%5D=true&columns%5B5%5D%5Borderable%5D=false&columns%5B5%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B5%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B6%5D%5Bdata%5D=value&columns%5B6%5D%5Bname%5D=value&columns%5B6%5D%5Bsearchable%5D=true&columns%5B6%5D%5Borderable%5D=false&columns%5B6%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B6%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B7%5D%5Bdata%5D=total&columns%5B7%5D%5Bname%5D=total&columns%5B7%5D%5Bsearchable%5D=true&columns%5B7%5D%5Borderable%5D=false&columns%5B7%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B7%5D%5Bsearch%5D%5Bregex%5D=false&columns%5B8%5D%5Bdata%5D=net_total&columns%5B8%5D%5Bname%5D=net_total&columns%5B8%5D%5Bsearchable%5D=true&columns%5B8%5D%5Borderable%5D=false&columns%5B8%5D%5Bsearch%5D%5Bvalue%5D=&columns%5B8%5D%5Bsearch%5D%5Bregex%5D=false&start=0&length=30&search%5Bvalue%5D=&search%5Bregex%5D=false&_=1712695888321");
                    message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/" + _idCarteira + "/");
                    message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                    message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                    message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                    message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                    message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                    message.Headers.Add("Cookie", cookie);
                    var result = client.Send(message);
                    result.EnsureSuccessStatusCode();
                    var jsonResponse = result.Content.ReadAsStringAsync();
                    resumoDTO.ProventosInfo = JsonConvert.DeserializeObject<ProventosDTO>(jsonResponse.Result);
                }

                resumoDTO.DataAtualizado = DateTime.Now;
                resumoDTO.Iniciado = true;

                HttpContext.Session.SetString(SessionIdCarteira, _idCarteira);
                HttpContext.Session.SetString(SessionCarteira, JsonConvert.SerializeObject(resumoDTO));
            }

            return Ok(resumoDTO);
        }

        public IActionResult Resumo(string ativo, string categoria)
        {
            switch (categoria)
            {
                case "acao":
                    carregaAcao(ativo);
                    break;

                case "fii":
                    carregaFii(ativo);
                    break;

                case "etf":
                    carregaEtf(ativo);
                    break;

                default:
                    break;
            }

            return Json(resumoDTO);
        }

        private void carregaAcao(string ativo)
        {
            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "/acoes/" + ativo + "/");
                message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/779708/");
                message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                var result = client.Send(message);
                result.EnsureSuccessStatusCode();
                var jsonResponse = result.Content.ReadAsStringAsync();
                resumoDTO.Resumo = jsonResponse.Result;
            }
        }

        private void carregaFii(string ativo)
        {
            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "/fiis/" + ativo + "/");
                message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/779708/");
                message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                var result = client.Send(message);
                result.EnsureSuccessStatusCode();
                var jsonResponse = result.Content.ReadAsStringAsync();
                resumoDTO.Resumo = jsonResponse.Result;
            }
        }

        private void carregaEtf(string ativo)
        {
            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "/etfs/" + ativo + "/");
                message.Headers.Add("Referer", "https://investidor10.com.br/carteiras/resumo/779708/");
                message.Headers.Add("Sec-Ch-Ua", "\"Not A(Brand\";v=\"99\", \"Opera GX\";v=\"107\", \"Chromium\";v=\"121\"");
                message.Headers.Add("Sec-Ch-Ua-Mobile", "?0");
                message.Headers.Add("Sec-Ch-Ua-Platform", "\"Windows\"");
                message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 OPR/107.0.0.0");
                message.Headers.Add("X-Csrf-Token", "s4D8X0AYgOi7N6W3PzO2QExfC5KhLye3rokmHkwy");
                var result = client.Send(message);
                result.EnsureSuccessStatusCode();
                var jsonResponse = result.Content.ReadAsStringAsync();
                resumoDTO.Resumo = jsonResponse.Result;
            }
        }
    }
}