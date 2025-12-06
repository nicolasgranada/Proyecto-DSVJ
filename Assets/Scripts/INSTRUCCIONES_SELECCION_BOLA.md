# Instrucciones para Configurar el Menú de Selección de Bola

## ✅ Scripts Creados

1. **BallSelector.cs** - Guarda el color de la bola seleccionada
2. **BallApplier.cs** - Aplica el color seleccionado al jugador cuando inicia el juego
3. **MainMenuUI.cs** - Actualizado con métodos para seleccionar diferentes colores de bola

## 🎨 Colores Disponibles

Los siguientes métodos están disponibles en `MainMenuUI`:
- `SelectBallRed()` - Bola roja
- `SelectBallBlue()` - Bola azul
- `SelectBallGreen()` - Bola verde
- `SelectBallYellow()` - Bola amarilla
- `SelectBallPurple()` - Bola morada
- `SelectBallOrange()` - Bola naranja
- `SelectBallDefault()` - Bola por defecto (rojo oscuro)

## 📋 Pasos para Configurar en Unity

### 1. Agregar el script BallApplier a la escena del juego

1. Abre la escena `SampleScene`
2. Crea un GameObject vacío (GameObject > Create Empty)
3. Nómbralo "BallApplier"
4. Arrastra el script `BallApplier.cs` al GameObject
5. Este script aplicará automáticamente el color seleccionado al jugador cuando inicie el juego

### 2. Crear botones en el menú principal

1. Abre la escena `Main Menu`
2. En el Canvas del menú, crea botones para cada color de bola:
   - Botón "Bola Roja"
   - Botón "Bola Azul"
   - Botón "Bola Verde"
   - Botón "Bola Amarilla"
   - Botón "Bola Morada"
   - Botón "Bola Naranja"
   - Botón "Bola Por Defecto"

3. Para cada botón:
   - Selecciona el botón
   - En el Inspector, busca el componente "Button"
   - En "On Click()", haz clic en el "+"
   - Arrastra el GameObject que tiene el script `MainMenuUI` al campo de objeto
   - Selecciona el método correspondiente:
     - `MainMenuUI > SelectBallRed()` para el botón rojo
     - `MainMenuUI > SelectBallBlue()` para el botón azul
     - Y así sucesivamente...

### 3. Opcional: Crear un panel de selección de bola

Puedes crear un panel separado (similar al panel de niveles) que se muestre cuando el usuario quiera seleccionar su bola:

1. Crea un nuevo Panel en el Canvas
2. Nómbralo "PanelSeleccionBola"
3. Agrega los botones de selección de bola dentro de este panel
4. Agrega métodos en `MainMenuUI.cs` para mostrar/ocultar este panel:
   ```csharp
   public GameObject panelSeleccionBola;
   
   public void ShowBallSelection()
   {
       if (panelSeleccionBola != null) panelSeleccionBola.SetActive(true);
       if (panelMenu != null) panelMenu.SetActive(false);
   }
   
   public void HideBallSelection()
   {
       if (panelSeleccionBola != null) panelSeleccionBola.SetActive(false);
       if (panelMenu != null) panelMenu.SetActive(true);
   }
   ```

## 🎮 Cómo Funciona

1. El usuario selecciona un color de bola en el menú principal
2. El color se guarda en `BallSelector.selectedBallColor`
3. Cuando el juego inicia, `BallApplier` aplica ese color al material del jugador
4. El jugador aparece con el color seleccionado

## 💡 Personalización

Si quieres agregar más colores o cambiar los existentes, edita los métodos en `MainMenuUI.cs` y ajusta los valores RGB en `new Color(r, g, b, a)`.


