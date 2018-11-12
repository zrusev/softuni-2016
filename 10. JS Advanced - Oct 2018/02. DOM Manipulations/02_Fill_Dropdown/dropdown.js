function addItem() {
  let text = document.getElementById('newItemText').value;
  let val = document.getElementById('newItemValue').value;

  let node = document.createElement('option');
  node.value = val;
  node.textContent = text;

  let sel = document.getElementById('menu');
  sel.appendChild(node);

  document.getElementById('newItemText').value = '';
  document.getElementById('newItemValue').value = '';
}