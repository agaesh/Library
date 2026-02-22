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

    input[type="search"] {
        width: 100%;
        padding: 12px 16px;
        font-size: 14px;
        border: 1px solid #a855f7; /* purple border */
        border-radius: 8px;
        background-color: #ffffff; /* white background */
        color: #4b0082; /* deep purple text */
        outline: none;
        transition: all 0.3s ease;
    }

    /* Focus state for better UX */
    input[type="search"]:focus {
        border-color: #7c3aed; /* stronger purple */
        box-shadow: 0 0 0 3px rgba(124, 58, 237, 0.2); /* subtle purple glow */
    }

    /* Placeholder styling */
    input[type="search"]::placeholder {
        color: #9c27b0; /* lighter purple for placeholder */
        opacity: 0.7;
    }

    .filters {
        display: flex;
        flex-wrap: wrap;
        gap: 8px;
        width: 100%;
        margin-bottom: 20px;
    }

    .filter-pil {
        background-color: #f3f4f6; /* light gray base */
        color: #0d1b2a; /* dark blue text for consistency */
        border: 1px solid #d1d5db;
        border-radius: 20px;
        padding: 8px 16px;
        font-size: 14px;
        font-weight: 500;
        cursor: pointer;
        transition: all 0.2s ease-in-out;
    }

    /* Hover: subtle gray highlight */
    .filter-pil:hover {
        background-color: #e5e7eb;
        border-color: #cbd5e1;
    }

    /* Focus: white background with a softer accent */
    .filter-pil:focus {
        background-color: #ffffff;
        color: #2563eb; /* professional blue accent (lighter than CTA dark blue) */
        border: 2px solid #2563eb;
        outline: none;
        box-shadow: 0 0 0 3px rgba(37, 99, 235, 0.25); /* subtle glow */
    }

    .filters .search-btn {
        margin-left: auto;
    }

    .search-btn {
        width: 100%;
    }

    .search-btn button {
        background-color: darkblue;
        cursor: pointer;
        width: 100%;
        color: white;
        padding: 10px;
        border-radius: 8px;
        font-weight: bolder;
        height: 40px;
    }

    .genre-select {
        border-radius: 20px;
        font-size: 14px;
        font-weight: 500;
        background-color: #f3f4f6; /* neutral gray */
        color: #0d1b2a; /* dark blue text */
        border: 1px solid #d1d5db;
        cursor: pointer;
        /* Add spacing around the arrow */
        padding: 6px 28px 6px 12px; /* extra right padding for arrow */
        appearance: none; /* remove default arrow */
        -webkit-appearance: none;
        -moz-appearance: none;
        background-image: url("data:image/svg+xml;utf8,<svg fill='%230d1b2a' height='16' viewBox='0 0 24 24' width='16' xmlns='http://www.w3.org/2000/svg'><path d='M7 10l5 5 5-5z'/></svg>");
        background-repeat: no-repeat;
        background-position: right 8px center; /* control arrow position */
        background-size: 16px;
    }

    .list-container{
        max-height:500px;
        overflow-x:scroll;
        height:auto;
    }
    @media (min-width: 600px) {
        .hamburger {
            display: none;
        }
        .search-btn {
            display: none;
        }

        .book-item {
            flex-direction: row; /* Side by side on bigger screens */
            align-items: center;
        }

        .book-image {
            flex: 1;
        }

        .book-details {
            flex: 2;
            padding: 0 10px;
        }

        .book-actions {
            flex: 1;
            justify-content: flex-end;
        }

        .list-container{
            overflow-x:hidden;
        }
    }
</style>
