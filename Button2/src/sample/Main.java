package sample;
import javafx.animation.TranslateTransition;
import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.Pane;
import javafx.scene.paint.Color;
import javafx.stage.Screen;
import javafx.stage.Stage;
import javafx.stage.StageStyle;
import javafx.util.Duration;

public class Main extends Application {

    Button button;
    vector2D buttonSize = new vector2D(200,50);

    private vector2D generateRandomPosition(){
        vector2D limit = new vector2D(Screen.getPrimary().getVisualBounds().getWidth() - buttonSize.X,
                Screen.getPrimary().getVisualBounds().getHeight() - buttonSize.Y);
        return new vector2D(Math.random()*limit.X, Math.random()*limit.Y);
    }

    private void animate(double seconds){
        TranslateTransition animation= new TranslateTransition();
        vector2D newPos = generateRandomPosition();
        System.out.println("new pos: " + newPos.X + " " + newPos.Y);
        animation.setDuration(Duration.seconds(seconds));
        animation.setToX(newPos.X);
        animation.setToY(newPos.Y);
        animation.setNode(button);
        animation.play();
    }

    private Scene getScene(){
        button = new Button("CLICK ME");
        button.setPrefSize(buttonSize.X, buttonSize.Y);
        button.setOnAction( event -> animate(0.5));

        Pane root = new Pane();
        root.getChildren().add(button);

        Scene scene = new Scene(root, Color.TRANSPARENT);
        scene.getStylesheets().add("transparent.css");
        animate(0.001);

        return scene;
    }

    @Override
    public void start(Stage primaryStage) throws Exception{

        Scene scene = getScene();

        primaryStage.setFullScreen(true);
        primaryStage.initStyle(StageStyle.TRANSPARENT);
        primaryStage.setScene(scene);
        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}