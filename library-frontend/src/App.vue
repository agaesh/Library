<script setup>
    import Sidebar from './components/Sidebar.vue'
</script>

<template>
    <div>
        <Sidebar />
        <h2>Admin Book Catalog</h2>
        <div style="display: flex; flex-direction:column; align-items: flex-start; gap: 1rem;">
            <div class="create-btn">
                <button>Add Books</button>
      </div>
            <input type="search" placeholder="Search Books" />
            <div class="search-btn">
                <button>Search Books</button>
  </div>
            <!--<div class="filters" style="display: flex; align-items: flex-start; gap: 0.3rem;">-->
            <div class="filters" style="display:flex; flex-direction:row;">
                <button class="button filter-pil">All</button>
                <button class="button filter-pil">In Stock</button>
                <button class="button filter-pil">Out Of Stock</button>
                <button class="button filter-pil">Low Stock</button>

                <!-- Genre filter -->
                <select class="filter-pil genre-select">
                    <option value="ALL">All Genres</option>
                    <option value="fiction">Fiction</option>
                    <option value="non-fiction">Non-Fiction</option>
                    <option value="fantasy">Fantasy</option>
                    <option value="science">Science</option>
                    <option value="history">History</option>
                    <option value="biography">Biography</option>
                </select>
            </div>
        </div>

        <div class="list-container">
            <TableList :headers="['#', 'Name', 'Status', 'Created', 'Actions']"
                       :rows="rows"
                       @edit="handleEdit"
                       @delete="handleDelete"
                       @assign="handleAssign"
                       @view="handleView" />
        </div>
    </div>
</template>

<style scoped>

</style>
