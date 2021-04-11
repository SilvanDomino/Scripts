<?php
    //Verbinding maken met database
    $servername = "127.0.0.1";
    $dbname = "c3163gpr2";

    $debug = false;
    if($debug){
        $username = "root";
        $password = "";
    } else {
        $username = "c3163hers";
        $password = "hers";
    }

    $conn = new mysqli($servername, $username, $password, $dbname);
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }
    echo "Connected successfully <br>";
    
    //Argumenten uit de URL halen (Query string)
    $name = $_GET["name"];
    $score = $_GET["score"];
    if(!empty($name) && !empty($score)){
        echo "name: ".$name."   score: ".$score."<br>";

        //SQL Statement om dingen in de database te stoppen
        $sql = "INSERT INTO highscores (score, name) VALUES(".$score.", '".$name."')";
        if($conn->query($sql) === TRUE){
            echo "New Record created successfully"."<br>";
        } else {
            echo "Error: ".$sql. "<br>".$conn->error;
        }
    } else {
        echo "No name or score provided in the query string<br>";
        echo "Read https://nl.wikipedia.org/wiki/Querystring for more information <br>";
        echo "You need to add a name and score to the query string";
    }

    
    $conn->close();
?>