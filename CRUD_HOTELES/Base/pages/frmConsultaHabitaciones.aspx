<%@ Page Title="Consulta de Habitaciones" Language="C#" MasterPageFile="~/Base/pages/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaHabitaciones.aspx.cs" Inherits="CRUD_HOTELES.Base.pages.frmConsultaHabitaciones" %>

<asp:Content ID="HeadX" ContentPlaceHolderID="head" runat="server">
  <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
  <script src="../../JavaScript/jquery.cookie.js"></script>
  <script src="../../JavaScript/Habitaciones.js"></script>
</asp:Content>

<asp:Content ID="MainX" ContentPlaceHolderID="MainContent" runat="server">

  <!-- Breadcrumb -->
  <nav aria-label="breadcrumb">
    <ol class="breadcrumb my-breadcrumb">
      <li class="breadcrumb-item"><a href="dashboard.aspx">Inicio</a></li>
      <li class="breadcrumb-item active" aria-current="page">Consulta de Habitaciones</li>
    </ol>
  </nav>


  <!-- FILTROS DE BÚSQUEDA -->
<div class="card card_border py-2 mb-4">
  <div class="cards__heading">
    <h3>Filtros de Búsqueda de Habitaciones</h3>
  </div>

  <div class="card-body">
    <form action="javascript:cargaListaHabitaciones()" method="post">
      <div class="form-row">
        <div class="col-md-4">
          <div class="input-group input-group-outline mb-3">
            <label  class="form-label" for="bsqHotel"></label>
              <select id="bsqHotel" class="form-control input-style">
              </select>
          </div>
        </div>
        <div class="col-md-4">
          <div class="input-group input-group-outline mb-3">
            <label class="form-label">Descripcion de la Habitacion</label>
            <input type="text" id="bsqDescHabitacion" class="form-control" maxlength="500" />
          </div>
        </div>
        <div class="col-md-4">
          <div class="input-group input-group-outline mb-3">
            <label class="form-label"></label>
            <select id="bsqEstado" class="form-control">
              <option value="A">Activo</option>
              <option value="I">Inactivo</option>
            </select>
          </div>
        </div>
      </div>

        <!-- BOTONES -->
        <div class="mt-4 d-flex gap-2">
          <button type="submit" class="btn bg-gradient-dark">Buscar</button>
          <button type="button" class="btn btn-outline-dark" onclick="javascript:crearHabitacion()">Crear nuevo</button>
        </div>
      </form>
    </div>
  </div>

  <!-- RESULTADOS DE BÚSQUEDA -->
  <div class="card card_border py-2 mb-4">
    <div class="cards__heading">
      <h3>Resultados de Búsqueda de Habitaciones</h3>
    </div>
    <div class="card-body table-responsive">
      <table id="tblHabitaciones" class="table table-striped table-bordered align-middle">
        <%-- Contenido dinámico cargado por Habitaciones.js --%>
      </table>
    </div>
  </div>

  <script>
      // Mostrar nombre de usuario (cookies globales)
      $(document).ready(function () {
          if ($.cookie) {
              $("#nombreUsuario").text($.cookie("GLBDSC") || "");
              $("#emlUsuario").text($.cookie("GLBCOD") || "");
          }
      });
  </script>

</asp:Content>
