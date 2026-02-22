<script setup>
    import Sidebar from './components/Sidebar.vue'
    import { ref, computed} from 'vue'
    import BookItem from './components/BookItem.vue'
    import TableList from './components/BookList.vue'
    

    const books = ref([
        {
            id: 1,
            name: 'Echo Is Everything', 
            author: 'Author Name',
            cover: 'https://images.template.net/453953/6x9-Book-Cover-Template-edit-online.png',
            status: 'active',
            createdAt: new Date()
        },
        {
            id: 2,
            name: 'Another Book',
            author: 'Second Author',
            cover: 'https://images.template.net/453953/6x9-Book-Cover-Template-edit-online.png',
            status: 'inactive',
            createdAt: new Date()
        }
    ])

    // Convert books into rows for TableList
    const rows = computed(() =>
        books.value.map((book, index) => [
            index + 1,                // #
            book.name,                // Name
            book.status,              // Status
            new Date(book.createdAt).toLocaleDateString() // Created
        ])
    )

    function handleEdit(row) {
        console.log('Edit clicked:', row)
    }
    function handleDelete(row) {
        console.log('Delete clicked:', row)
    }
    function handleAssign(row) {
        console.log('Assign clicked:', row)
    }
    function handleView(row) {
        console.log('View clicked:', row)
    }

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
    .create-btn{
        align-self:flex-end;
    }
    .create-btn button {
        background-color: #3b82f6;
        color: white;
        border-radius: 8px;
    }

</style>
