<%@ Page Title="Mantenimiento de Hoteles" Language="C#" MasterPageFile="~/Base/pages/Site.Master"
    AutoEventWireup="true" CodeBehind="frmMantenimientoHoteles.aspx.cs"
    Inherits="CRUD_HOTELES.Base.pages.frmMantenimientoHoteles" %>

<asp:Content ID="HeadX" ContentPlaceHolderID="head" runat="server">
  <style>
    /* Fondo principal */
    body {
      background: url('../../Login/images/banner2.jpg') no-repeat center center fixed;
      background-size: cover;
    }

    /* Contenedor principal */
    .card-mantenimiento {
      background: rgba(0, 0, 0, 0.8);
      border-left: 5px solid #e50914;
      border-radius: 10px;
      color: #fff;
      padding: 2.5rem;
      max-width: 950px;
      margin: 2.5rem auto 4rem;
      box-shadow: 0 4px 15px rgba(0, 0, 0, .4);
    }

    .card-mantenimiento label {
      font-weight: 600;
      color: #ccc;
    }

    .card-mantenimiento input,
    .card-mantenimiento select,
    .card-mantenimiento textarea {
      background: transparent;
      border: 1px solid #555;
      color: #fff;
      border-radius: 4px;
    }

    .card-mantenimiento input::placeholder,
    .card-mantenimiento textarea::placeholder {
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
      <li class="breadcrumb-item"><a href="frmConsultaHoteles.aspx" class="text-white-50">Consulta de Hoteles</a></li>
      <li class="breadcrumb-item active text-white" aria-current="page">Mantenimiento de Hotel</li>
    </ol>

    <div class="card-mantenimiento">
      <h3 class="mb-4 text-white">Mantenimiento de Hoteles</h3>

      <div class="row">
        <div class="col-md-4 mb-3">
          <label class="d-block mb-1">Código del hotel</label>
          <input type="text" id="txtCodigo" class="form-control online_book bg-transparent text-white"
                 placeholder="Ej: H001" required />
        </div>
        <div class="col-md-8 mb-3">
          <label class="d-block">Nombre del hotel</label>
          <input type="text" id="txtNombre" class="form-control online_book bg-transparent text-white"
                 placeholder="Hotel Paraíso" required />
        </div>
      </div>

      <div class="mb-3">
        <label class="d-block">Descripción</label>
        <input type="text" id="txtDescripcion" class="form-control online_book bg-transparent text-white" required />
      </div>

      <div class="mb-3">
        <label class="d-block">Dirección física</label>
        <input type="text" id="txtDireccion" class="form-control online_book bg-transparent text-white" required />
      </div>

      <div class="row">
        <div class="col-md-4 mb-3">
          <label class="d-block">Teléfono</label>
          <input type="tel" id="txtTelefono" class="form-control online_book bg-transparent text-white"
                 maxlength="15" required />
        </div>
        <div class="col-md-4 mb-3">
          <label class="d-block">Correo</label>
          <input type="email" id="txtCorreo" class="form-control online_book bg-transparent text-white" required />
        </div>
        <div class="col-md-4 mb-3">
          <label class="d-block">Sitio web</label>
          <input type="url" id="txtUrl" class="form-control online_book bg-transparent text-white" required />
        </div>
      </div>

      <div class="row">
        <div class="col-md-4 mb-3">
          <label class="d-block">Área (m²)</label>
          <input type="number" id="txtArea" class="form-control online_book bg-transparent text-white" required />
        </div>
        <div class="col-md-4 mb-3">
          <label class="d-block">Fecha de construcción</label>
          <input type="date" id="txtFecha" class="form-control online_book bg-transparent text-white" required />
        </div>
        <div class="col-md-4 mb-3">
          <label class="d-block">Estado</label>
          <select id="cboEstado" class="form-control online_book bg-transparent text-white" required>
            <option class="text-dark" value="A">Activo</option>
            <option class="text-dark" value="I">Inactivo</option>
          </select>
        </div>
      </div>

      <!-- Botones -->
      <div class="text-center mt-4">
        <button type="button" class="btn bg-gradient-dark" onclick="mantenimientoHotel()">Guardar</button>
        <button type="button" class="btn btn-light" onclick="regresar()">Regresar</button>
      </div>
    </div>
  </div>

</asp:Content>

<asp:Content ID="ScriptsX" ContentPlaceHolderID="ScriptsContent" runat="server">
  <script src="../../JavaScript/Hoteles.js"></script>
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

