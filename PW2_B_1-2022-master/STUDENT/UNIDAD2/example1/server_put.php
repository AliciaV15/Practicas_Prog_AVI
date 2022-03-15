<?php
    header('Content-Type: application/json');
    include_once 'dbconfig.php';

    $conn = new mysqli($servername, $username, $password, $database, $port);

    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    $product = json_decode(file_get_contents('php://input'), true);

    $sql = "UPDATE product SET name=?, description=?, price=? WHERE id=?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('ssdi', $product['name'], $product['description'], 
                      $product['price'], $product['id']);

    $stmt->execute();
    $conn->close();

    echo json_encode(array('result' => 'ok'));
?>
