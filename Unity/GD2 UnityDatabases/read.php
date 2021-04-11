<?php
    //Inloggen in de database
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
    
    //SQL statement runnen
    $sql = "SELECT * FROM highscores";
    $result = $conn->query($sql);
    
    //Resultaat naar de browser sturen.
    if($result->num_rows > 0){
        echo json_encode($result->fetch_all());
    } else {
        echo "0 results";
    }
    
    $conn->close();
?>