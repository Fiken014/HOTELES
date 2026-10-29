<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Base/pages/Site.Master"
    AutoEventWireup="true" CodeBehind="dashboard.aspx.cs"
    Inherits="CRUD_HOTELES.Base.pages.dashboard" %>

<asp:Content ID="HeadX" ContentPlaceHolderID="head" runat="server">
  <!-- Plugins específicos de esta página -->
  <script src="<%= ResolveUrl("~/Base/assets/js/plugins/chartjs.min.js") %>"></script>
</asp:Content>

<asp:Content ID="MainX" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="ms-3">
      <h3 class="mb-0 h4 font-weight-bolder">Panel de Control</h3>
      <p class="mb-4">Consulte las ventas, el valor y la tasa de reservas</p>
    </div>

    <!-- KPI CARDS -->
    <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
      <div class="card">
        <div class="card-header p-2 ps-3">
          <div class="d-flex justify-content-between">
            <div>
              <p class="text-sm mb-0 text-capitalize">Ingresos del Día</p>
              <h4 class="mb-0">$53k</h4>
            </div>
            <div class="icon icon-md icon-shape bg-gradient-dark shadow-dark shadow text-center border-radius-lg">
              <i class="material-symbols-rounded opacity-10">money_bag</i>
            </div>
          </div>
        </div>
        <hr class="dark horizontal my-0">
        <div class="card-footer p-2 ps-3">
          <p class="mb-0 text-sm"><span class="text-success font-weight-bolder">+55% </span>que la semana pasada</p>
        </div>
      </div>
    </div>

    <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
      <div class="card">
        <div class="card-header p-2 ps-3">
          <div class="d-flex justify-content-between">
            <div>
              <p class="text-sm mb-0 text-capitalize">Usuarios Nuevos</p>
              <h4 class="mb-0">2300</h4>
            </div>
            <div class="icon icon-md icon-shape bg-gradient-dark shadow-dark shadow text-center border-radius-lg">
              <i class="material-symbols-rounded opacity-10">person</i>
            </div>
          </div>
        </div>
        <hr class="dark horizontal my-0">
        <div class="card-footer p-2 ps-3">
          <p class="mb-0 text-sm"><span class="text-success font-weight-bolder">+3% </span>que el último mes</p>
        </div>
      </div>
    </div>

    <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
      <div class="card">
        <div class="card-header p-2 ps-3">
          <div class="d-flex justify-content-between">
            <div>
              <p class="text-sm mb-0 text-capitalize">Hoteles Vistos</p>
              <h4 class="mb-0">150</h4>
            </div>
            <div class="icon icon-md icon-shape bg-gradient-dark shadow-dark shadow text-center border-radius-lg">
              <i class="material-symbols-rounded opacity-10">visibility</i>
            </div>
          </div>
        </div>
        <hr class="dark horizontal my-0">
        <div class="card-footer p-2 ps-3">
          <p class="mb-0 text-sm"><span class="text-danger font-weight-bolder">-2% </span>que ayer</p>
        </div>
      </div>
    </div>

    <div class="col-xl-3 col-sm-6">
      <div class="card">
        <div class="card-header p-2 ps-3">
          <div class="d-flex justify-content-between">
            <div>
              <p class="text-sm mb-0 text-capitalize">Reservas Activas</p>
              <h4 class="mb-0">13,430</h4>
            </div>
            <div class="icon icon-md icon-shape bg-gradient-dark shadow-dark shadow text-center border-radius-lg">
              <i class="material-symbols-rounded opacity-10">weekend</i>
            </div>
          </div>
        </div>
        <hr class="dark horizontal my-0">
        <div class="card-footer p-2 ps-3">
          <p class="mb-0 text-sm"><span class="text-danger font-weight-bolder">-5% </span>que ayer</p>
        </div>
      </div>
    </div>
  </div>

  <!-- CHARTS -->
  <div class="row">
    <div class="col-lg-4 col-md-6 mt-4 mb-4">
      <div class="card">
        <div class="card-body">
          <h6 class="mb-0">Visitas del sitio web</h6>
          <p class="text-sm">Rendimiento de la última campaña</p>
          <div class="pe-2">
            <div class="chart">
              <canvas id="chart-bars" class="chart-canvas" height="170"></canvas>
            </div>
          </div>
          <hr class="dark horizontal">
          <div class="d-flex">
            <i class="material-symbols-rounded text-sm my-auto me-1">schedule</i>
            <p class="mb-0 text-sm">campaña enviada hace 2 días</p>
          </div>
        </div>
      </div>
    </div>

    <div class="col-lg-4 col-md-6 mt-4 mb-4">
      <div class="card">
        <div class="card-body">
          <h6 class="mb-0">Reservas Canceladas por Mes</h6>
        <p class="text-sm">(<span class="font-weight-bolder">-15%</span>) menos que el mes pasado.</p>
          <div class="pe-2">
            <div class="chart">
              <canvas id="chart-line" class="chart-canvas" height="170"></canvas>
            </div>
          </div>
          <hr class="dark horizontal">
          <div class="d-flex">
            <i class="material-symbols-rounded text-sm my-auto me-1">schedule</i>
            <p class="mb-0 text-sm">actualizado hace 5 min</p>
          </div>
        </div>
      </div>
    </div>

    <div class="col-lg-4 mt-4 mb-3">
      <div class="card">
        <div class="card-body">
          <h6 class="mb-0">Tareas de mantenimiento por Mes</h6>
          <p class="text-sm">Rendimiento del último Sondeo</p>
          <div class="pe-2">
            <div class="chart">
              <canvas id="chart-line-tasks" class="chart-canvas" height="170"></canvas>
            </div>
          </div>
          <hr class="dark horizontal">
          <div class="d-flex">
            <i class="material-symbols-rounded text-sm my-auto me-1">schedule</i>
            <p class="mb-0 text-sm">recién actualizado</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>

<asp:Content ID="ScriptsX" ContentPlaceHolderID="ScriptsContent" runat="server">
  <!-- Charts Init -->
  <script>
    var ctx = document.getElementById("chart-bars").getContext("2d");
    new Chart(ctx, {
      type: "bar",
      data: {
        labels: ["M","T","W","T","F","S","S"],
        datasets: [{
          label: "Views", tension: 0.4, borderWidth: 0, borderRadius: 4,
            borderSkipped: false, backgroundColor: "#007bff",
          data: [50,45,22,28,50,60,76], barThickness: 'flex'
        }]
      },
      options: {
        responsive: true, maintainAspectRatio: false,
        plugins: { legend: { display: false } },
        interaction: { intersect: false, mode: 'index' },
        scales: {
          y: { grid: { drawBorder:false, display:true, drawOnChartArea:true, drawTicks:false, borderDash:[5,5], color:'#e5e5e5' },
               ticks: { suggestedMin:0, suggestedMax:500, beginAtZero:true, padding:10, font:{size:14,lineHeight:2}, color:"#737373" } },
          x: { grid: { drawBorder:false, display:false, drawOnChartArea:false, drawTicks:false, borderDash:[5,5] },
               ticks: { display:true, color:'#737373', padding:10, font:{size:14, lineHeight:2} } }
        }
      }
    });

    var ctx2 = document.getElementById("chart-line").getContext("2d");
    new Chart(ctx2, {
      type: "line",
      data: {
        labels: ["J","F","M","A","M","J","J","A","S","O","N","D"],
        datasets: [{
          label: "Sales", tension:0, borderWidth:2, pointRadius:3,
            pointBackgroundColor:"#007bff", pointBorderColor:"transparent",
            borderColor:"#007bff", backgroundColor:"transparent", fill:true,
          data: [120,230,130,440,250,360,270,180,90,300,310,220], maxBarThickness:6
        }]
      },
      options: {
        responsive:true, maintainAspectRatio:false,
        plugins:{ legend:{display:false},
          tooltip:{ callbacks:{ title:function(c){ const m=["January","February","March","April","May","June","July","August","September","October","November","December"]; return m[c[0].dataIndex]; } } } },
        interaction:{ intersect:false, mode:'index' },
        scales:{
          y:{ grid:{ drawBorder:false, display:true, drawOnChartArea:true, drawTicks:false, borderDash:[4,4], color:'#e5e5e5' },
              ticks:{ display:true, color:'#737373', padding:10, font:{size:12, lineHeight:2} } },
          x:{ grid:{ drawBorder:false, display:false, drawOnChartArea:false, drawTicks:false, borderDash:[5,5] },
              ticks:{ display:true, color:'#737373', padding:10, font:{size:12, lineHeight:2} } }
        }
      }
    });

    var ctx3 = document.getElementById("chart-line-tasks").getContext("2d");
    new Chart(ctx3, {
      type: "line",
      data: {
        labels: ["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"],
        datasets: [{
          label: "Tasks", tension:0, borderWidth:2, pointRadius:3,
            pointBackgroundColor:"#007bff", pointBorderColor:"transparent",
            borderColor:"#007bff", backgroundColor:"transparent", fill:true,
          data: [10,5,1,3,6,8,3,8,4,7,14,21], maxBarThickness:6
        }]
      },
      options: {
        responsive:true, maintainAspectRatio:false, plugins:{ legend:{display:false} },
        interaction:{ intersect:false, mode:'index' },
        scales:{
          y:{ grid:{ drawBorder:false, display:true, drawOnChartArea:true, drawTicks:false, borderDash:[4,4], color:'#e5e5e5' },
              ticks:{ display:true, padding:10, color:'#737373', font:{size:14, lineHeight:2} } },
          x:{ grid:{ drawBorder:false, display:false, drawOnChartArea:false, drawTicks:false, borderDash:[4,4] },
              ticks:{ display:true, color:'#737373', padding:10, font:{size:14, lineHeight:2} } }
        }
      }
    });
  </script>

  <!-- Smooth scrollbar on Windows -->
  <script>
      var win = navigator.platform.indexOf('Win') > -1;
      if (win && document.querySelector('#sidenav-scrollbar')) {
          Scrollbar.init(document.querySelector('#sidenav-scrollbar'), { damping: '0.5' });
      }
  </script>
  <script async defer src="https://buttons.github.io/buttons.js"></script>
</asp:Content>
