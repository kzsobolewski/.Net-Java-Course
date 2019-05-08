package sample;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.Pane;
import javafx.stage.Screen;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

public class Main extends Application {

    Button button = new Button("CLICK ME");
    vector2D buttonSize = new vector2D(100,50);


    private class vector2D{
        public double X;
        public double Y;

        public vector2D(double x, double y) {
            X = x;
            Y = y;
        }
    }

    private vector2D generateRandomPosition(){
        vector2D limit = new vector2D(Screen.getPrimary().getVisualBounds().getWidth() - buttonSize.X,
                Screen.getPrimary().getVisualBounds().getHeight() - buttonSize.Y);
        vector2D random = new vector2D(Math.random()*limit.X, Math.random()*limit.Y);
        return random;
    }

    private void changeStagePosition(Stage primaryStage, vector2D newPos){
        primaryStage.setX(newPos.X);
        primaryStage.setY(newPos.Y);
    }


    private Pane createPaneWithButton(Stage primaryStage){
        Pane root = new Pane();
        root.setBackground(null);
        button.setPrefWidth(buttonSize.X);
        button.setPrefHeight(buttonSize.Y);
        button.setOnAction(e  -> {
                vector2D newPosition = generateRandomPosition();
                changeStagePosition(primaryStage, newPosition);
        } );
        root.getChildren().add(button);
        return root;
    }

    @Override
    public void start(Stage primaryStage) throws Exception{

        Scene scene = new Scene(createPaneWithButton(primaryStage));
        primaryStage.initStyle(StageStyle.TRANSPARENT);
        changeStagePosition(primaryStage, generateRandomPosition());
        primaryStage.setScene(scene);
        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
