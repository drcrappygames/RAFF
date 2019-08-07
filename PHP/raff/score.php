<?php 
        $db = mysqli_connect('localhost', 'id1217000_scorehandler', 'score', 'id1217000_raff'); 

        $id = mysqli_real_escape_string($db,  $_GET['id']);
        $score = mysqli_real_escape_string($db, $_GET['score']); 
        $hash = $_GET['hash']; 
 
        $secretKey="meh";

        $real_hash = md5($id . $score . $secretKey); 

        if($real_hash == $hash) { 
			$query = "insert into highscores values ('$id', '$score');"; 
			$result = mysqli_query($db, $query);
        } 
?>