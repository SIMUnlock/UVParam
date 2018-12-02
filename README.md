# UVParam

Banco de parámetros físicos en las costas de Veracruz.


Upload API

Method: Post 
https://uvparametros.azurewebsites.net/RemoteUpload/{idEquipo}/{idEstacion}

Ejemplo


    <form method="post" enctype="multipart/form-data" action="https://uvparametros.azurewebsites.net/RemoteUpload/2/3">
        <div class="form-group">

          

            <div class="form-group col-md-12 col-sm-12 col-xs-12">
                <br />
                <input type="file" name="files" multiple />

           
            </div>
        </div>
        <div class="form-group text-left">

            <input type="submit" value="Cargar" />

        </div>
    </form>
