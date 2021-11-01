var productController;

// Model layer

class Product {
    constructor(name, price, quantity, description) {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.description = description;
    }
}


// Controller

class ProductController {
    constructor() {
        this.txtName = document.getElementById('txtName');
        this.txtPrice = document.getElementById('txtPrice');
        this.txtQuantity = document.getElementById('txtQuantity');
        this.txtDescription = document.getElementById('txtDescription');
        
        this.tbBody = document.getElementById('tbBody');

        this.products = new Array();
    }

    addProduct() {
        let name = this.txtName.value;
        let price = parseInt(this.txtPrice.value);
        let quantity = parseInt(this.txtQuantity.value);
        let description = this.txtDescription.value;

        let product = new Product(name, price, quantity, description);
        this.products.push(product);

        this.displayProducts();

        this.txtName.value = '';
        this.txtPrice.value = '';
        this.txtQuantity.value = '';
        this.txtDescription.value = '';
        
    }

    deleteProduct(i) {
        this.products.splice(i, 1);
        this.displayProducts();
    }

    displayProducts() {
        this.tbBody.innerHTML = '';

        for (let i in this.products) {
            let product = this.products[i];

            let tr = document.createElement('tr');

            let tdName = document.createElement('td');
            tdName.innerHTML = product.name;

            let tdPrice = document.createElement('td');
            tdPrice.innerHTML = product.price + "bs.";

            let tdQuantity = document.createElement('td');
            tdQuantity.innerHTML = product.quantity;

            let tdDescription = document.createElement('td');
            tdDescription.innerHTML = product.description;

            

            let tdOption = document.createElement('td');
            let btnDelete = document.createElement('button');

            btnDelete.type = 'button';
            btnDelete.innerHTML = 'Delete';
            btnDelete.className = 'btn btn-success';
            btnDelete.onclick = function() {
                productController.deleteProduct(i);
            }

            tdOption.appendChild(btnDelete);

            tr.appendChild(tdName);
            tr.appendChild(tdPrice);
            tr.appendChild(tdQuantity);
            tr.appendChild(tdDescription);
           
            tr.appendChild(tdOption);

            this.tbBody.appendChild(tr);
        }
    }
}

window.onload = function() {
    productController = new ProductController();
}