<%@ Page Title="Mantenimiento de Habitaciones" Language="C#" MasterPageFile="~/Base/pages/Site.Master"
    AutoEventWireup="true" CodeBehind="frmMantenimientoHabitaciones.aspx.cs"
    Inherits="CRUD_HOTELES.Base.pages.frmMantenimientoHabitaciones" %>

<asp:Content ID="HeadX" ContentPlaceHolderID="head" runat="server">

  <style>
    body {
      background: url('../../Login/images/habitaciones-hotel.jpg') no-repeat center center fixed;
      background-size: cover;
    }

    .card-mantenimiento {
      background: rgba(0, 0, 0, 0.8);
      border-left: 5px solid #e50914; /* rojo del login */
      border-radius: 10px;
      color: #fff;
      padding: 2rem;
      max-width: 800px;
      margin: 4rem auto;
      box-shadow: 0px 4px 15px rgba(0, 0, 0, 0.4);
    }

    .card-mantenimiento label {
      font-weight: 600;
      color: #ccc;
    }

    .card-mantenimiento input,
    .card-mantenimiento select {
      background: transparent;
      border: 1px solid #555;
      color: #fff;
      border-radius: 4px;
    }

    .card-mantenimiento input::placeholder {
      color: #888;
    }

    .card-mantenimiento .btn-primary {
      background: #007bff;
      border: none;
      font-weight: 600;
    }

    .card-mantenimiento .btn-primary:hover {
      background: #0056b3;
    }

    .card-mantenimiento .btn-light {
      background: #f8f9fa;
      color: #000;
    }

    .card-mantenimiento .btn-light:hover {
      background: #e2e6ea;
    }

  </style>

  <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
  <script src="../../JavaScript/jquery.cookie.js"></script>

</asp:Content>


<asp:Content ID="MainX" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container">
  <ol class="breadcrumb bg-transparent p-0 mb-3 text-white">
    <li class="breadcrumb-item"><a href="dashboard.aspx" class="text-white-50">Inicio</a></li>
    <li class="breadcrumb-item"><a href="frmConsultaHabitaciones.aspx" class="text-white-50">Consulta Habitaciones</a></li>
    <li class="breadcrumb-item active text-white" aria-current="page">Mantenimiento de Habitaciones</li>
  </ol>
  <div class="card-mantenimiento">
    <h3 class="mb-4 text-white">Mantenimiento de Habitaciones</h3>
    <div class="row">
      <div class="col-md-6 mb-3">
        <label>Descripción de la Habitación</label>
        <input type="text" id="txtDescripcion" class="form-control" placeholder="Ej: Suite Ejecutiva" required />
      </div>
      <div class="col-md-6 mb-3">
        <label>Tipo de Habitación</label>
        <input type="text" id="txtTipoHabitacion" class="form-control" placeholder="Ej: Doble, Individual..." required />
      </div>
    </div>

    <div class="row">
      <div class="col-md-6 mb-3">
        <label>Hotel</label>
        <select id="cboHotel" class="form-control"></select>
      </div>
      <div class="col-md-6 mb-3">
        <label>Estado</label>
        <select id="cboEstado" class="form-control">
          <option class="text-dark" value="A">Activo</option>
          <option class="text-dark" value="I">Inactivo</option>
        </select>
      </div>
    </div>

    <div class="text-center mt-4">
      <button type="button" class="btn bg-gradient-dark" onclick="mantenimientoHabitacion()">Guardar</button>
      <button type="button" class="btn btn-light" onclick="regresar()">Regresar</button>
    </div>
  </div>
</div>
</asp:Content>


<asp:Content ID="ScriptsX" ContentPlaceHolderID="ScriptsContent" runat="server">
  <script src="../../JavaScript/Habitaciones.js"></script>
  <script>
      $(document).ready(function () {
          const usuario = $.cookie("GLBDSC");
          if (!usuario) {
              Swal.fire({
                  icon: "warning",
                  title: "Sesión no iniciada",
                  text: "Por favor, inicie sesión para continuar.",
                  confirmButtonText: "Ir al login"
              }).then(() => {
                  window.location.href = "../../Login/frmInicioSesion.aspx";
              });
          }
      });
  </script>
</asp:Content>

