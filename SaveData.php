<?php
  $score=$_REQUEST['score'];
  $server = 'localhost';
  $username = 'Student';
  $password = 'NicCage';
  $database = 'hers_myRunner';
  //sanitize input

  //check if score was empty. Remember to put ?score=### after your url to insert a score
  if($score != ""){
    //make connection with the database
    $database = mysqli_connect($server, $username, $password, $database) or die('Failed to connect: ' . mysql_error());

    //create the SQL statement used to insert data into the database
    //use your own table name, value names and values.
    $query="INSERT INTO HighScores(ID, Score) VALUES(DEFAULT, '$score');";
    //Run the SQL query
    $result=mysqli_query($query);
    //If no error occured this gets printed. If nothing happens in the database, this means that the SQL query wasn't executed.
    echo "$result success?";
  } else{
    echo "Bro score was empty bro";
  }

 ?>
